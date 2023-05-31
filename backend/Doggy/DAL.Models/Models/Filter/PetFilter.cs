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

        public PetTypeEnum? PetType { get; set; }

        public PetStatusEnum? PetStatus { get; set; }

        public IQueryable<Pet> Filter(DbSet<Pet> pets)
        {
            var query = pets.Include(x => x.Shelter);

            if (!string.IsNullOrWhiteSpace(PetName))
            {
                query = (IIncludableQueryable<Pet, Shelter>)query
                    .Where(x => x.PetName.ToLower()
                        .Contains(PetName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(ShelterName))
            {
                query = (IIncludableQueryable<Pet, Shelter>)query
                    .Where(x => x.PetName.ToLower()
                        .Contains(PetName.ToLower()));
            }

            if (PetType.HasValue)
            {
                query = (IIncludableQueryable<Pet, Shelter>)query
                    .Where(x => x.PetType == PetType.Value);
            }

            if (PetStatus.HasValue)
            {
                query = (IIncludableQueryable<Pet, Shelter>)query
                    .Where(x => x.PetStatus == PetStatus.Value);
            }

            return query;
        }
    }
}
