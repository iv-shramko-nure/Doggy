using System;

namespace DAL.Contracts
{
    public interface IUnitOfWork
    {
        Lazy<IPetRepository> Pets { get; }

        Lazy<IShelterRepository> Shelters { get; }
    }
}
