using AutoMapper;
using BLL.Contracts;
using BLL.Models.Models.ShelterModels;
using DAL.Contracts;
using DAL.Models.Models.Filter;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ShelterService : IShelterService
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IMapper> _mapper;

        public ShelterService(
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IMapper> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Guid Apply(ShelterDTO model)
        {
            var shelter = _mapper.Value.Map<Shelter>(model);

            return _unitOfWork.Value.Shelters.Value.Apply(shelter);
        }

        public void Delete(Guid shelterId)
        {
            _unitOfWork.Value.Shelters.Value.Delete(shelterId);
        }

        public ShelterDTO GetShelterById(Guid shelterId)
        {
            var result = _unitOfWork.Value.Shelters.Value.GetById(shelterId);
            var resultModel = _mapper.Value.Map<ShelterDTO>(result);

            return resultModel;
        }

        public List<ShelterListItemDTO> List(ShelterFilter filter)
        {
            var result = _unitOfWork.Value.Shelters.Value.Find(filter).ToList();
            var resultModel = _mapper.Value.Map<List<ShelterListItemDTO>>(result);

            return resultModel;
        }
    }
}
