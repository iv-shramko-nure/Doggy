using DAL.Models.Models;
using Domain.Models;
using System;
using System.Linq;

namespace DAL.Contracts
{
    public interface IUserRepository
    {
        Guid Apply(User user);

        void Delete(Guid userId);

        IQueryable<User> GetAll();

        User GetById(Guid userId);

        void AddPatron(PatronDataModel patronModel);

        void DeletePatron(Guid patronId);

        void SetLike(LikeDataModel likeModel);

        void DeleteLike(LikeDataModel likeModel);
    }
}
