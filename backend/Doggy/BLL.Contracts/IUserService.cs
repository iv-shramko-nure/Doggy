using BLL.Models.Models.UserModels;
using DAL.Models.Models;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IUserService
    {
        Guid Apply(UserDTO model);

        void List();

        void Delete(Guid userId);

        UserDTO GetById(Guid userId);

        void SetLike(LikeDataModel model);

        void RemoveLike(LikeDataModel model);

        void AddPatron(PatronDataModel model);

        void RemovePatron(PatronDataModel model);
    }
}
