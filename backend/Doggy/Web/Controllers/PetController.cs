﻿using System;
using System.Collections.Generic;
using BLL.Contracts;
using BLL.Models.Models.PetModels;
using DAL.Models.Models.Filter;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly Lazy<IPetService> _petService;

        public PetController(
           Lazy<IPetService> petService)
        {
            _petService = petService;
        }

        [HttpGet("{petId}")]
        public APIResponse<PetDTO> GetPetById(Guid petId)
        {
            var response = new APIResponse<PetDTO>();
            var pet = _petService.Value.GetById(petId);

            response.IsSuccess = true;
            response.data = pet;

            return response;
        }

        [HttpPost]
        public APIResponse Apply(PetDTO petModel)
        {
            var response = new APIResponse();
            _petService.Value.Apply(petModel);

            response.IsSuccess = true;

            return response;
        }

        //[Authorize]
        [HttpDelete("delete/{petId}")]
        public APIResponse DeletePet(Guid petId)
        {
            var response = new APIResponse();
            _petService.Value.Delete(petId);

            response.IsSuccess = true;

            return response;
        }

        [HttpGet("list")]
        public APIResponse<List<PetListItemDTO>> Filter(PetFilter petFilter)
        {
            var response = new APIResponse<List<PetListItemDTO>>();
            var data = _petService.Value.List(petFilter);

            response.IsSuccess = true;
            response.data = data;

            return response;
        }
    }
}
