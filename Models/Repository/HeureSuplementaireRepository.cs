using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace API.Models.Repository
{ 
    public class HeureSuplementaireRepository : IHeureSuplementaireRepository
    {
        private readonly AppDbContext appDbContext;

        public HeureSuplementaireRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<HeureSupplementaire> Add(HeureSupplementaire Obj)
        {
            var result = await appDbContext.HeureSupplementaires.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<HeureSupplementaire> Delete(int id)
        {
            var result = await appDbContext.HeureSupplementaires.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {


                appDbContext.HeureSupplementaires.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<HeureSupplementaire> GetById(int Id)
        {

            return await appDbContext.HeureSupplementaires.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<HeureSupplementaire> GetByCriteria(string Libelle)
        {
            return await appDbContext.HeureSupplementaires.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<HeureSupplementaire>> GetALL()
        {
            return await appDbContext.HeureSupplementaires.ToListAsync();
        }

        public async Task<HeureSupplementaire> Update(HeureSupplementaire obj)
        {

            var result = await GetById(obj.Id);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.Id = obj.Id;

                    result.CodeHeureSuivant = obj.CodeHeureSuivant;

                    result.Libelle = obj.Libelle;

                    result.NBMax = obj.NBMax;

                    result.Taux = obj.Taux;


                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<HeureSupplementaire>> Search(String name)
        {

            IQueryable<HeureSupplementaire> query = appDbContext.HeureSupplementaires;
            if (!string.IsNullOrEmpty(name))
            {
                
                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
