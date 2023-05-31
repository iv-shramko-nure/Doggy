using BLL.Models.Models.UserModels;
using DAL.Models.Models;
using DAL.Models.Models.Filter;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IUserService
    {
        Guid Apply(UserDTO model);

        List<UserListItemDTO> List(UserFilter filter);

        void Delete(Guid userId);

        UserDTO GetById(Guid userId);

        void SetLike(LikeDataModel model);

        void RemoveLike(LikeDataModel model);

        void AddPatron(PatronDataModel model);

        void RemovePatron(Guid patronId);
    }
}
