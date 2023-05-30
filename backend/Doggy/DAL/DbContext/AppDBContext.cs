using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContext
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options) { }

        public DbSet<User> UserProfiles { get; set; }

        public DbSet<Shelter> Shelters { get; set; }

        //public DbSet<Like> Likes { get; set; }
        
        public DbSet<Pet> Pet { get; set; }

        //public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapModels(modelBuilder);
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Pets)
            //    .WithOne(p => p.User)
            //    .HasForeignKey(u => u.UserId);

            //modelBuilder.Entity<Pet>()
            //    .HasOne(p => p.Patron)
            //    .WithMany(u => u.PatronizedPets)
            //    .HasForeignKey(p => p.PatronId);

            //modelBuilder.Entity<Like>()
            //    .HasKey(l => new { l.UserId, l.PetId });
        }

        private void MapModels(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.IdentityUserId)
                .IsUnique();

            //builder.Entity<User>()
            //    .HasMany(u => u.Pets)
            //    .WithOne(p => p.User)
            //    .HasForeignKey(u => u.UserId)
            //    .OnDelete(DeleteBehavior.SetNull);

            //builder.Entity<User>()
            //    .HasMany(u => u.Likes)
            //    .WithOne(l => l.User)
            //    .HasForeignKey(u => u.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Location>()
            //    .HasMany(l => l.Users)
            //    .WithOne(u => u.Location)
            //    .HasForeignKey(l => l.LocationId);

            //builder.Entity<Shelter>()
            //    .HasOne(s => s.Location)
            //    .WithOne(l => l.Shelter);

            //builder.Entity<Shelter>()
            //    .HasMany(s => s.Pets)
            //    .WithOne(p => p.Shelter)
            //    .HasForeignKey(s => s.ShelterId)
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
