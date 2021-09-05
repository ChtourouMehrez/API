using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class CongeRepository : ICongeRepository
    {
        private readonly AppDbContext appDbContext;

        public CongeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Conge> Add(Conge Obj)
        {
            var result = await appDbContext.Conges.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Conge> Delete(int id)
        {
            var result = await appDbContext.Conges.FirstOrDefaultAsync(e => e.CongeId == id);
            if (result != null)
            {


                appDbContext.Conges.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Conge> GetById(int Id)
        {

            return await appDbContext.Conges.FirstOrDefaultAsync(e => e.CongeId == Id);
        }

        public async Task<Conge> GetByCriteria(string Libelle)
        {
            return await appDbContext.Conges.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<Conge>> GetALL()
        {
            return await appDbContext.Conges.ToListAsync();
        }

        public async Task<Conge> Update(Conge obj)
        {

            var result = await GetById(obj.CongeId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.CongeId = obj.CongeId;

                    result.Libelle = obj.Libelle;

                    result.CongeNonPaye = obj.CongeNonPaye;

                    result.ForceMajeur = obj.ForceMajeur;

                    result.TauxForceMajeurCompteSolde  = obj.TauxForceMajeurCompteSolde;

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Conge>> Search(String name)
        {

            IQueryable<Conge> query = appDbContext.Conges;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
