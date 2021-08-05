using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
namespace API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

 
        public DbSet<Organigramme> Organigrammes { get; set; }

        public DbSet<Qualification>Qualifications { get; set; }





    }
}
