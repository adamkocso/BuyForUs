using buyforus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Name = "Donator", NormalizedName = "Donator".ToUpper() },
                new IdentityRole { Name = "Organization", NormalizedName = "Organization".ToUpper() }
            );
        }
    }
}