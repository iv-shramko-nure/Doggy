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
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IMapper> _mapper;

        public PetService(
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IMapper> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Apply(PetDTO petModel)
        {
            var pet = _mapper.Value.Map<PetDTO, Pet>(petModel);

            _unitOfWork.Value.Pets.Value.Apply(pet);
        }

        public void Delete(Guid petId)
        {
            _unitOfWork.Value.Pets.Value.Delete(petId);
        }

        public PetDTO GetById(Guid petId)
        {
            var pet = _unitOfWork.Value.Pets.Value.GetById(petId);
            var petDTO = _mapper.Value.Map<Pet, PetDTO>(pet);

            return petDTO;
        }

        public List<PetListItemDTO> List(PetFilter filter)
        {
            var pets = _unitOfWork.Value.Pets.Value.Find(filter).ToList();
            var petListItems = _mapper.Value.Map<List<Pet>, List<PetListItemDTO>>(pets);

            return petListItems;
        }
    }
}
