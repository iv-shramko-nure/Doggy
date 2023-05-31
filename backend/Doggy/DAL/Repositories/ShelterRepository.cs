using DAL.Contracts;
using DAL.DbContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DAL.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly DbSet<Shelter> _shelters;
        private readonly AppDBContext _dbContext;

        public ShelterRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _shelters = _dbContext.Shelters;
        }

        public Guid Apply(Shelter shelter)
        {
            var oldShelter = _shelters.FirstOrDefault(s => s.ShelterId == shelter.ShelterId);

            if (oldShelter is null)
            {
                _shelters.Add(shelter);
                _dbContext.Commit();

                return shelter.ShelterId;
            }

            _shelters.Update(shelter);
            _dbContext.Commit();

            return shelter.ShelterId;
        }

        public void Delete(Guid shelterId)
        {
            var shelter = _shelters.FirstOrDefault(s => s.ShelterId == shelterId);

            if (shelter is null)
                throw new ArgumentException("INVALID_SHELTERID");

            _shelters.Remove(shelter);
            _dbContext.Commit();
        }

        public IQueryable<Shelter> GetAll()
        {
            return _shelters.AsQueryable();
        }

        public Shelter GetById(Guid shelterId)
        {
            var shelter = _shelters.FirstOrDefault(s => s.ShelterId == shelterId);

            if (shelter is null)
                throw new ArgumentException("INVALID_SHELTERID");

            return shelter;
        }
    }
}
