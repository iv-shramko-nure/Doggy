using System;
using System.Linq;
using DAL.Contracts;
using DAL.DbContext;
using DAL.Models.Models.Filter;

using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly DbSet<Pet> _pets;
        private readonly AppDBContext _dBContext;

        public PetRepository(AppDBContext dBContext)
        {
            _dBContext = dBContext;
            _pets = dBContext.Pets;
        }

        public Guid Apply(Pet pet)
        {
            var oldPet = _pets.FirstOrDefault(x => x.PetId == pet.PetId);

            if (oldPet is null)
            {
                _pets.Add(pet);
                _dBContext.Commit();

                return pet.PetId;
            }

            _pets.Update(pet);
            _dBContext.Commit();

            return pet.PetId;
        }

        public void Delete(Guid petId)
        {
            var pet = _pets.FirstOrDefault(x => x.PetId == petId);
            if (pet is null)
                throw new ArgumentException("INVALID_PETID");

            _pets.Remove(pet);
            _dBContext.SaveChanges();
        }

        public IQueryable<Pet> Find(PetFilter filter)
        {
            return filter.Filter(_pets);
        }

        public IQueryable<Pet> GetAll()
        {
            return _pets.AsQueryable();
        }

        public Pet GetById(Guid petId)
        {
            var pet = _pets.FirstOrDefault(x => x.PetId == petId);
            if (pet is null)
                throw new ArgumentException("INVALID_PETID");

            return pet;
        }
    }
}
