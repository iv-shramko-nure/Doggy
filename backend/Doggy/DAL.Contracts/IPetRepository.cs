using System;
using System.Linq;
using Domain.Models;

namespace DAL.Contracts
{
    public interface IPetRepository
    {
        Guid Apply(Pet pet);

        void Delete(Guid petId);

        IQueryable<Pet> GetAll();

        Pet GetById(Guid petid);
    }
}
