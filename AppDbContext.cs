using Microsoft.EntityFrameworkCore;
using Models;
namespace API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Code to seed data
            //more PRIMARY kEY THAN One
            modelBuilder.Entity<Personnel>().HasKey(X => new { X.PersonnelKey, X.SessionKey });
        }

        public DbSet<Organigramme> Organigrammes { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<TypePrime> TypePrimes { get; set; }



        public DbSet<TypeContrat> TypeContrats { get; set; }

        public DbSet<TypePaies> TypePaie { get; set; }

        public DbSet<Regime> Regimes { get; set; }
        public DbSet<Echelon> Echelons { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Conge> Conges { get; set; }

        public DbSet<ServiceDepartement> ServiceDepartements { get; set; }
        public DbSet<JoursFerie> JoursFeries { get; set; }

        public DbSet<Grille> Grilles { get; set; }
        public DbSet<Nature> Natures { get; set; }
        public DbSet<TypeCNSS> TypeCNSSs { get; set; }

        public DbSet<ModeReglement> ModeReglements { get; set; }
        public DbSet<Banque> Banques { get; set; }
        public DbSet<ChargePatronale> ChargePatronales { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DbSet<PrimePersonnel> PrimePersonnels { get; set; }


        

    }
}
