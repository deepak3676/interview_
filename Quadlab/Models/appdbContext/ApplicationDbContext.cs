using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Quadlab.Models.appdbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<modelClass> UserTable1 { get; set; }
        public DbSet<country> CountryTable1 { get; set; }
        public DbSet<cities> CitiesTable1 { get; set;}

    }
}
