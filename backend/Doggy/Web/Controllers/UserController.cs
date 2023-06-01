using BLL.Contracts;
using BLL.Models.Models.UserModels;
using DAL.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Lazy<IUserService> _userService;

        public UserController(
            Lazy<IUserService> userService)
        {
            _userService = userService;
        }

        [HttpPost("add-patron")]
        public APIResponse AddPatron(PatronDataModel patronModel)
        {
            var response = new APIResponse();
            _userService.Value.AddPatron(patronModel);

            response.IsSuccess = true;

            return response;
        }

        [HttpPost]
        public APIResponse Apply(UserDTO userModel)
        {
            var response = new APIResponse();
            _userService.Value.Apply(userModel);

            response.IsSuccess = true;

            return response;
        }

        [HttpDelete("delete/{petId}")]
        public APIResponse Delete(Guid userId)
        {
            var response = new APIResponse();
            _userService.Value.Delete(userId);

            response.IsSuccess = true;

            return response;
        }

        [HttpGet("{userId}")]
        public APIResponse<UserDTO> GetUserById(Guid userId)
        {
            var response = new APIResponse<UserDTO>();
            var user = _userService.Value.GetById(userId);

            response.IsSuccess = true;
            response.data = user;

            return response;
        }

        [HttpPost("remove-like")]
        public APIResponse RemoveLike(LikeDataModel likeModel)
        {
            var response = new APIResponse();
            _userService.Value.RemoveLike(likeModel);

            return response;
        }

        [HttpPost("remove-patron/{patronId}")]
        public APIResponse RemovePatron(Guid patronId)
        {
            var response = new APIResponse();
            _userService.Value.RemovePatron(patronId);

            return response;
        }

        public APIResponse SetLike(LikeDataModel likeModel)
        {
            var response = new APIResponse();
            _userService.Value.SetLike(likeModel);

            response.IsSuccess = true;

            return response;
        }
    }
}
