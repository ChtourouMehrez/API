using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class JoursFerieRepository : IJoursFerieRepository
    {
        private readonly AppDbContext appDbContext;

        public JoursFerieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<JoursFerie> Add(JoursFerie Obj)
        {
            var result = await appDbContext.JoursFeries.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<JoursFerie> Delete(int id)
        {
            var result = await appDbContext.JoursFeries.FirstOrDefaultAsync(e => e.JoursFerieId == id);
            if (result != null)
            {


                appDbContext.JoursFeries.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<JoursFerie> GetById(int Id)
        {

            return await appDbContext.JoursFeries.FirstOrDefaultAsync(e => e.JoursFerieId == Id);
        }

        public async Task<JoursFerie> GetByCriteria(string Libelle)
        {
            return await appDbContext.JoursFeries.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<JoursFerie>> GetALL()
        {
            return await appDbContext.JoursFeries.ToListAsync();
        }

        public async Task<JoursFerie> Update(JoursFerie obj)
        {

            var result = await GetById(obj.JoursFerieId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.JoursFerieId = obj.JoursFerieId;


                    result.Libelle = obj.Libelle;

                    result.DateDu = obj.DateDu;

                    result.DateAu = obj.DateAu;

                    result.Chome = obj.Chome;

                    result.Paye = obj.Paye;


                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<JoursFerie>> Search(String name)
        {

            IQueryable<JoursFerie> query = appDbContext.JoursFeries;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
