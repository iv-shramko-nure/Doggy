using DAL.Models.Models.Filter;
using Domain.Models;
using System;
using System.Linq;

namespace DAL.Contracts
{
    public interface IShelterRepository
    {
        Guid Apply(Shelter shelter);

        void Delete(Guid shelterId);

        IQueryable<Shelter> Find(ShelterFilter filter);

        IQueryable<Shelter> GetAll();

        Shelter GetById(Guid shelterId);
    }
}
