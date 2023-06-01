using AutoMapper;
using DAL.Contracts;
using DAL.DbContext;
using DAL.Models.Models.Filter;
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
        private readonly Lazy<IMapper> _mapper;

        public ShelterRepository(
            AppDBContext dbContext,
            Lazy<IMapper> mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

            _dbContext.Entry(oldShelter).State = EntityState.Detached;

            oldShelter = _mapper.Value.Map<Shelter, Shelter>(shelter);
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

        public IQueryable<Shelter> Find(ShelterFilter filter)
        {
            return filter.Filter(_shelters);
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
