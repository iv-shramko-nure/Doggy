using AutoMapper;
using BLL.Contracts;
using BLL.Models.Models.UserModels;
using DAL.Contracts;
using DAL.Models.Models;
using DAL.Models.Models.Filter;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IMapper> _mapper;

        public UserService(
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IMapper> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddPatron(PatronDataModel model)
        {
            _unitOfWork.Value.Users.Value.AddPatron(model);
        }

        public Guid Apply(UserDTO model)
        {
            var user = _mapper.Value.Map<User>(model);

            return _unitOfWork.Value.Users.Value.Apply(user);
        }

        public void Delete(Guid userId)
        {
            _unitOfWork.Value.Users.Value.Delete(userId);
        }

        public UserDTO GetById(Guid userId)
        {
            var user = _unitOfWork.Value.Users.Value.GetById(userId);

            return _mapper.Value.Map<UserDTO>(user);
        }

        public List<UserListItemDTO> List(UserFilter filter)
        {
            var result = _unitOfWork.Value.Users.Value.Find(filter).ToList();
            var resultModel = _mapper.Value.Map<List<UserListItemDTO>>(result);

            return resultModel;
        }

        public void RemoveLike(LikeDataModel model)
        {
            _unitOfWork.Value.Users.Value.DeleteLike(model);
        }

        public void RemovePatron(Guid patronId)
        {
            _unitOfWork.Value.Users.Value.DeletePatron(patronId);
        }

        public void SetLike(LikeDataModel model)
        {
            _unitOfWork.Value.Users.Value.SetLike(model);
        }
    }
}
