using BLL.Contracts;
using BLL.Models.Models.ShelterModels;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly Lazy<IShelterService> _shelterService;

        public ShelterController(
            Lazy<IShelterService> shelterService)
        {
            _shelterService = shelterService;
        }

        [HttpGet("{shelterId}")]
        public APIResponse<ShelterDTO> GetShelterById(Guid shelterId)
        {
            var response = new APIResponse<ShelterDTO>();
            var shelter = _shelterService.Value.GetShelterById(shelterId);

            response.IsSuccess = true;
            response.data = shelter;

            return response;
        }

        [HttpPost]
        public APIResponse Apply(ShelterDTO shelterModel)
        {
            var response = new APIResponse();
            _shelterService.Value.Apply(shelterModel);

            response.IsSuccess = true;

            return response;
        }

        [HttpDelete("delete/{shelterId}")]
        public APIResponse Delete(Guid shelterId)
        {
            var response = new APIResponse();
            _shelterService.Value.Delete(shelterId);

            response.IsSuccess = true;

            return response;
        }
    }
}
