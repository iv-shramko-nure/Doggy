using System;
using DAL.Contracts;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            Lazy<IPetRepository> pets)
        {
            Pets = pets;
        }

        public Lazy<IPetRepository> Pets { get; }
    }
}
