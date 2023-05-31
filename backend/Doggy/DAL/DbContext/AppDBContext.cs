using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace DAL.DbContext
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }

        public DbSet<User> UserProfiles { get; set; }

        public DbSet<Shelter> Shelters { get; set; }

        public DbSet<Like> Likes { get; set; }
        
        public DbSet<Pet> Pets { get; set; }

        public DbSet<Patron> Patrons { get; set; }

        public DbSet<PetPost> PetPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapModels(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void MapModels(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.IdentityUserId)
                .IsUnique();

            builder.Entity<User>()
                .Property(x => x.UserId)
                .HasValueGenerator(typeof(GuidValueGenerator));
            
            builder.Entity<Pet>()
                .Property(x => x.PetId)
                .HasValueGenerator(typeof(GuidValueGenerator));

            builder.Entity<Shelter>()
                .Property(x => x.ShelterId)
                .HasValueGenerator(typeof(GuidValueGenerator));

            builder.Entity<Patron>()
                .Property(x => x.UserId)
                .HasValueGenerator(typeof(GuidValueGenerator));

            builder.Entity<PetPost>()
                .Property(x => x.UserId)
                .HasValueGenerator(typeof(GuidValueGenerator));
            
            builder.Entity<Like>()
                .Property(x => x.LikeId)
                .HasValueGenerator(typeof(GuidValueGenerator));
        }
    }
}
