using System.Linq;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DAL.Models.Models.Filter
{
    public class PetFilter : IFilter<Pet>
    {
        public string PetName { get; set; }

        public string ShelterName { get; set; }

        public string Breed { get; set; }

        public PetTypeEnum? PetType { get; set; }

        public PetStatusEnum? PetStatus { get; set; }

        public IQueryable<Pet> Filter(DbSet<Pet> pets)
        {
            var query = pets.AsQueryable();

            if (!string.IsNullOrWhiteSpace(PetName))
            {
                query = query.Where(x => x.PetName.ToLower()
                    .Contains(PetName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(Breed))
                query = query.Where(x => x.Breed.ToLower() == Breed.ToLower());

            if(!string.IsNullOrWhiteSpace(ShelterName))
            {
                query = query.Where(x => x.Shelter.ShelterName.ToLower()
                    .Contains(ShelterName.ToLower()));
            }

            if (PetType.HasValue)
                query = query.Where(x => x.PetType == PetType.Value);

            if (PetStatus.HasValue)
                query = query.Where(x => x.PetStatus == PetStatus.Value);

            return query;
        }
    }
}
