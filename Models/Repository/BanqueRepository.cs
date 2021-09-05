using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class BanqueRepository : IBanqueRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public BanqueRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public BanqueRepository()
        {
        }

        public async Task<Banque> Add(Banque obj)
        {
            var result = await appDbContext.Banques.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Banque> Delete(int id)
        {
            var result = await appDbContext.Banques.FirstOrDefaultAsync(e => e.BanqueId == id);
            if (result != null)
            {


                appDbContext.Banques.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Banque> GetById(int Id)
        {

            return await appDbContext.Banques.FirstOrDefaultAsync(e => e.BanqueId == Id);
        }



        public async Task<IEnumerable<Banque>> GetALL()
        {
            return await appDbContext.Banques.ToListAsync();
        }

        public async Task<Banque> Update(Banque objs)
        {

            var result = await GetById(objs.BanqueId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {
                    //public int BanqueId { get; set; }
                    //public string CodeBanque { get; set; }
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
                    result.BanqueId = objs.BanqueId;

                    result.CodeBanque = objs.CodeBanque;
                    result.RaisonSociale = objs.RaisonSociale;

                    result.Siege = objs.Siege;
                    result.Adresse = objs.Adresse;

                    result.CodePostal = objs.CodePostal;

                    result.Ville = objs.Ville;
                    result.Paye = objs.Paye;

                    result.Tel = objs.Tel;
                    result.Fax = objs.Fax;
                    result.Email = objs.Email;
                    result.SiteWeb = objs.SiteWeb;

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Banque>> Search(String name)
        {

            IQueryable<Banque> query = appDbContext.Banques;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.RaisonSociale.Contains(name) || e.Adresse.Contains(name) || e.Tel.ToString().Contains(name) || e.Paye.Contains(name) || e.CodePostal.ToString().Contains(name) || e.Siege.Contains(name) || e.Ville.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Banque> GetByCriteria(string Libelle)
        {
            return await appDbContext.Banques.FirstOrDefaultAsync(e => e.RaisonSociale == Libelle);

        }

    }
}

