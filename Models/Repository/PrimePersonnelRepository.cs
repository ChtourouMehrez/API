using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class PrimePersonnelRepository : IPrimePersonnelRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public PrimePersonnelRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public PrimePersonnelRepository()
        {
        }

        public async Task<PrimePersonnel> Add(PrimePersonnel obj)
        {
            var result = await appDbContext.PrimePersonnels.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PrimePersonnel> Delete(int id)
        {
            var result = await appDbContext.PrimePersonnels.FirstOrDefaultAsync(e => e.PrimePersonnelId == id);
            if (result != null)
            {


                appDbContext.PrimePersonnels.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PrimePersonnel> GetById(int Id)
        {

            return await appDbContext.PrimePersonnels.FirstOrDefaultAsync(e => e.PrimePersonnelId == Id);
        }



        public async Task<IEnumerable<PrimePersonnel>> GetALL()
        {
            return await appDbContext.PrimePersonnels.ToListAsync();
        }

        public async Task<PrimePersonnel> Update(PrimePersonnel objs)
        {

            var result = await GetById(objs.PrimePersonnelId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {
                    //public int PrimePersonnelId { get; set; }
                    //public string CodePrimePersonnel { get; set; }
                    //public string RaisonSociale { get; set; }
                    //public string Siege { get; set; }
                    //public string Adresse { get; set; }
                    //public int CodePostal { get; set; }
                    //public string Ville { get; set; }
                    //public string Paye { get; set; }
                    //public int Tel { get; set; }
                    //public int Fax { get; set; }

                    //[EmailDomainValidator(AllowedDomain = "Domaine.com")]
                    //public string Email { get; set; }
                    //public string SiteWeb { get; set; }
                    result.PrimePersonnelId = objs.PrimePersonnelId;

                    result.montant = objs.montant;
                    result.Personnel = objs.Personnel;

                    result.PersonnelKey = objs.PersonnelKey;
                    result.PrimePersonnelId = objs.PrimePersonnelId;

                    result.TypePrime = objs.TypePrime;

                    result.TypePrimeId = objs.TypePrimeId;


                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<PrimePersonnel>> Search(String name)
        {

            IQueryable<PrimePersonnel> query = appDbContext.PrimePersonnels;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e=> e.TypePrime.Libelle.ToString().Contains(name) || e.Personnel.NomPrenom.Contains(name) || e.montant.ToString().Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<PrimePersonnel> GetByCriteria(string Libelle)
        {
            return await appDbContext.PrimePersonnels.FirstOrDefaultAsync(e => e.TypePrime.Libelle == Libelle|| e.Personnel.NomPrenom == Libelle);

        }

    }
}

