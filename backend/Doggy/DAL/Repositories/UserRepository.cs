using AutoMapper;
using DAL.Contracts;
using DAL.DbContext;
using DAL.Models.Models;
using DAL.Models.Models.Filter;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly DbSet<Patron> _patrons;
        private readonly DbSet<Like> _likes;
        private readonly DbSet<Pet> _pets;
        private readonly AppDBContext _dbContext;
        private readonly Lazy<IMapper> _mapper;

        public UserRepository(
            AppDBContext dbContext,
            Lazy<IMapper> mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _users = _dbContext.UserProfiles;
            _patrons = _dbContext.Patrons;
            _likes = _dbContext.Likes;
        }

        public void AddPatron(PatronDataModel patronModel)
        {
            var patron = _mapper.Value.Map<Patron>(patronModel);

            var user = _users.FirstOrDefault(u => u.UserId == patron.UserId);
            if (user is null)
                throw new ArgumentException("INVALID_USERID");

            var pet = _pets.FirstOrDefault(p => p.PetId == patron.PetId);
            if (pet is null)
                throw new ArgumentException("INVALID_PETID");

            _patrons.Add(patron);
            _dbContext.Commit();
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

            _dbContext.Entry(oldUser).State = EntityState.Detached;

            oldUser = _mapper.Value.Map<User, User>(user);
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

        public void DeleteLike(LikeDataModel dataModel)
        {
            var like = _likes.FirstOrDefault(l => l.UserId == dataModel.UserId && l.PetId == dataModel.PetId);
            if (like is null)
                throw new ArgumentException("INVALID_PETID_OR_USERID");

            _likes.Remove(like);
            _dbContext.Commit();
        }

        public void DeletePatron(Guid patronId)
        {
            var patron = _patrons.FirstOrDefault(p => p.PatronId == patronId);
            if (patron is null)
                throw new ArgumentException("INVALID_PATRONID");

            _patrons.Remove(patron);
            _dbContext.Commit();
        }

        public IQueryable<User> Find(UserFilter filter)
        {
            return filter.Filter(_users);
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

        public void SetLike(LikeDataModel likeModel)
        {
            var like = _mapper.Value.Map<Like>(likeModel);

            var user = _users.FirstOrDefault(u => u.UserId == like.UserId);
            if (user is null)
                throw new ArgumentException("INVALID_USERID");

            var pet = _pets.FirstOrDefault(p => p.PetId == like.PetId);
            if (pet is null)
                throw new ArgumentException("INVALID_PETID");

            _likes.Add(like);
            _dbContext.Commit();
        }
    }
}
