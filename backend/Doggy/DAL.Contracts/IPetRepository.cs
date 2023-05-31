using System;
using System.Linq;
using DAL.Models.Models.Filter;
using Domain.Models;

namespace DAL.Contracts
{
    public interface IPetRepository
    {
        Guid Apply(Pet pet);

        void Delete(Guid petId);

        IQueryable<Pet> Find(PetFilter filter);

        IQueryable<Pet> GetAll();

        Pet GetById(Guid petid);
    }
}
