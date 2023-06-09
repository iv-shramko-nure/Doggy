﻿using System.Linq;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models.Models.Filter
{
    public class UserFilter : IFilter<User>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public IQueryable<User> Filter(DbSet<User> users)
        {
            var query = users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(FullName))
            {
                query = query.Where(x => x.FullName.ToLower()
                    .Contains(FullName.ToLower()));
            }


            if (!string.IsNullOrWhiteSpace(Email))
            {
                query = query.Where(x => x.IdentityUser.Email.ToLower()
                    .Contains(Email.ToLower()));
            }

            return query;

        }
    }
}
