using System;
using DAL.Contracts;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            Lazy<IPetRepository> pets,
            Lazy<IShelterRepository> shelters,
            Lazy<IUserRepository> users)
        {
            Pets = pets;
            Shelters = shelters;
            Users = users;
        }

        public Lazy<IPetRepository> Pets { get; }

        public Lazy<IShelterRepository> Shelters { get; }

        public Lazy<IUserRepository> Users { get; }
    }
}
