using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Contracts;
using BLL.Models.Models.PetModels;
using DAL.Contracts;
using DAL.Models.Models.Filter;
using Domain.Models;

namespace BLL.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Apply(PetDTO petModel)
        {
            var pet = _mapper.Map<PetDTO, Pet>(petModel);

            _unitOfWork.Pets.Value.Apply(pet);
        }

        public void Delete(Guid petId)
        {
            _unitOfWork.Pets.Value.Delete(petId);
        }

        public PetDTO GetById(Guid petId)
        {
            var pet = _unitOfWork.Pets.Value.GetById(petId);
            var petDTO = _mapper.Map<Pet, PetDTO>(pet);

            return petDTO;
        }

        public List<PetListItemDTO> List(PetFilter filter)
        {
            var pets = _unitOfWork.Pets.Value.Find(filter).ToList();
            var petListItems = _mapper.Map<List<Pet>, List<PetListItemDTO>>(pets);

            return petListItems;
        }
    }
}
