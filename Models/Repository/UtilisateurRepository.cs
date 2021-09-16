using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public UtilisateurRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public UtilisateurRepository()
        {
        }

        public async Task<Utilisateur> Add(Utilisateur obj)
        {
            var result = await appDbContext.Utilisateurs.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Utilisateur> Delete(int id)
        {
            var result = await appDbContext.Utilisateurs.FirstOrDefaultAsync(e => e.UtilisateurId == id);
            if (result != null)
            {


                appDbContext.Utilisateurs.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Utilisateur> GetById(int Id)
        {

            return await appDbContext.Utilisateurs.FirstOrDefaultAsync(e => e.UtilisateurId == Id);
        }



        public async Task<IEnumerable<Utilisateur>> GetALL()
        {
            return await appDbContext.Utilisateurs.ToListAsync();
        }

        public async Task<Utilisateur> Update(Utilisateur objs)
        {

            var result = await GetById(objs.UtilisateurId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {
                    //public int UtilisateurId { get; set; }
                    //public string CodeUtilisateur { get; set; }
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
                    result.UtilisateurId = objs.UtilisateurId;
                    result.motdepasse = objs.motdepasse;
                    result.NomUtilisateur = objs.NomUtilisateur;
                    result.Administrateur = objs.Administrateur;



                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Utilisateur>> Search(String name)
        {

            IQueryable<Utilisateur> query = appDbContext.Utilisateurs;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.RaisonSociale.Contains(name) || e.Adresse.Contains(name) || e.Tel.ToString().Contains(name) || e.Paye.Contains(name) || e.CodePostal.ToString().Contains(name) || e.Siege.Contains(name) || e.Ville.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Utilisateur> GetByCriteria(string Libelle)
        {
            return await appDbContext.Utilisateurs.FirstOrDefaultAsync(e => e.RaisonSociale == Libelle);

        }

    }
}

