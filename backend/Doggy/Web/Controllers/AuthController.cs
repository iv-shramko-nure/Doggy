using AutoMapper;
using BLL.Contracts;
using BLL.Models.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.Models;
using Identity = Microsoft.AspNetCore.Identity;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly Lazy<IMapper> _mapper;

        public AuthController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration config,
            IUserService userService, 
            Lazy<IMapper> mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _userService = userService;
            _mapper = mapper;
        }

        [Route("login")]
        [HttpPost]
        public async Task<APIResponse<string>> Login(LoginDTO loginDTO)
        {
            APIResponse<string> response = new APIResponse<string>();

            IdentityUser user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user != null)
            {
                Identity.SignInResult result = await _signInManager.CheckPasswordSignInAsync(
                    user,
                    loginDTO.Password,
                    false
                );

                if (result.Succeeded)
                {
                    Claim[] claims = new[] { new Claim(JwtRegisteredClaimNames.Sub, user.Id), };

                    byte[] secretBytes = Encoding.UTF8.GetBytes(
                        _config.GetSection("Constants")["Secret"]
                    );

                    SymmetricSecurityKey key = new SymmetricSecurityKey(secretBytes);

                    SigningCredentials signinCredentials = new SigningCredentials(
                        key,
                        SecurityAlgorithms.HmacSha256
                    );

                    JwtSecurityToken token = new JwtSecurityToken(
                        _config.GetSection("Constants")["Issuer"],
                        _config.GetSection("Constants")["Audiance"],
                        claims,
                        DateTime.Now,
                        DateTime.Now.AddHours(1),
                        signinCredentials
                    );

                    string tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

                    response.IsSuccess = true;
                    response.data = tokenJson;
                }
            }

            return response;
        }

        [Route("register")]
        [HttpPost]
        public async Task<APIResponse<string>> Register(UserRegisterDTO registerDTO)
        {
            var response = new APIResponse<string>();

            string userName = registerDTO.Email.Split("@")[0];
            IdentityUser user = new IdentityUser()
            {
                Email = registerDTO.Email,
                UserName = userName
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                var userIdentity = await _userManager.FindByEmailAsync(registerDTO.Email);

                var userDTO = _mapper.Value.Map<UserDTO>(userIdentity);
                userDTO.IdentityUserId = userIdentity.Id;

                _userService.Apply(userDTO);
            }
            
            response.IsSuccess = result.Succeeded;

            return response;
        }

        [Route("logout")]
        [HttpGet]
        public async Task<APIResponse<string>> LogOut()
        {
            var response = new APIResponse<string>();

            try
            {
                await _signInManager.SignOutAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
