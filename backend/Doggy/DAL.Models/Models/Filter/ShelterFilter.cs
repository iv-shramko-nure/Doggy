using System;
using System.Linq;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models.Models.Filter
{
    public class ShelterFilter : IFilter<Shelter>
    {
        public string ShelterName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? OpeningTime { get; set; }

        public DateTime? ClosingTime { get; set; }

        public IQueryable<Shelter> Filter(DbSet<Shelter> shelters)
        {
            var query = shelters.AsQueryable();

            if (!string.IsNullOrWhiteSpace(ShelterName))
            {
                query = query.Where(x => x.ShelterName.ToLower()
                    .Contains(ShelterName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber.ToLower()
                    .Contains(PhoneNumber.ToLower()));
            }

            if (OpeningTime.HasValue)
                query = query.Where(x => x.OpeningTime == OpeningTime);

            if (ClosingTime.HasValue)
                query = query.Where(x => x.ClosingTime == ClosingTime);

            return query;
        }
    }
}
