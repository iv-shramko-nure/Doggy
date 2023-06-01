using BLL.Contracts;
using BLL.Models.Models.UserModels;
using Braintree;
using DAL.Models.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly Lazy<IBraintreeService> _braintreeService;

        public UserController(
            Lazy<IUserService> userService,
            Lazy<IBraintreeService> braintreeService)
        {
            _userService = userService;
            _braintreeService = braintreeService;
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

        [HttpPost("set-like")]
        public APIResponse SetLike(LikeDataModel likeModel)
        {
            var response = new APIResponse();
            _userService.Value.SetLike(likeModel);

            response.IsSuccess = true;

            return response;
        }

        [Authorize]
        [HttpPost("make-payment")]
        public APIResponse MakePayment(string nonce, decimal amount)
        {
            var response = new APIResponse();
            var gateway = _braintreeService.Value.GetGateway();
            
            var request = new TransactionRequest
            {
                Amount = amount,
                PaymentMethodNonce = nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            var result = gateway.Transaction.Sale(request);
            if (!result.IsSuccess())
                response.IsSuccess = false;
            else
                response.IsSuccess = true;

            return response;
        }

        [Authorize]
        [HttpGet("get-client-token")]
        public APIResponse<string> GetClientToken()
        {
            var response = new APIResponse<string>();

            var clientToken = _braintreeService.Value
                .GetGateway()
                .ClientToken
                .Generate();

            response.IsSuccess = true;
            response.data = clientToken;

            return response;
        }
    }
}
