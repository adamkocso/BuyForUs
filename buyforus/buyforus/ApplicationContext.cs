using buyforus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
