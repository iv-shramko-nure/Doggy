using DAL.Contracts;
using DAL.DbContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _users = _dbContext.UserProfiles;
        }

        public Guid Apply(User user)
        {
            var oldUser = _users.FirstOrDefault(u => u.UserId == user.UserId);

            if (oldUser is null)
            {
                _users.Add(user);
                _dbContext.Commit();

                return user.UserId;
            }

            _users.Update(user);
            _dbContext.Commit();

            return user.UserId;
        }

        public void Delete(Guid userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user is null)
                throw new ArgumentException("INVALID_USERID");

            _users.Remove(user);
            _dbContext.Commit();
        }

        public IQueryable<User> GetAll()
        {
            return _users.AsQueryable();
        }

        public User GetById(Guid userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user is null)
                throw new ArgumentException("INVALID_USERID");

            return user;
        }
    }
}
