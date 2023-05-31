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
    }
}
