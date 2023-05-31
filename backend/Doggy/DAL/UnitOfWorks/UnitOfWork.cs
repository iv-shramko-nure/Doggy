using System;
using DAL.Contracts;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            Lazy<IPetRepository> pets,
            Lazy<IShelterRepository> shelters)
        {
            Pets = pets;
            Shelters = shelters;
        }

        public Lazy<IPetRepository> Pets { get; }

        public Lazy<IShelterRepository> Shelters { get; }
    }
}
