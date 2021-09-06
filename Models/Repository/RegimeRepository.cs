using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class RegimeRepository : IRegimeRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public RegimeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public RegimeRepository()
        {
        }

        public async Task<Regime> Add(Regime obj)
        {
            var result = await appDbContext.Regimes.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Regime> Delete(int id)
        {
            var result = await appDbContext.Regimes.FirstOrDefaultAsync(e => e.RegimeId == id);
            if (result != null)
            {


                appDbContext.Regimes.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Regime> GetById(int Id)
        {

            return await appDbContext.Regimes.FirstOrDefaultAsync(e => e.RegimeId == Id);
        }



        public async Task<IEnumerable<Regime>> GetALL()
        {
            return await appDbContext.Regimes.ToListAsync();
        }

        public async Task<Regime> Update(Regime objs)
        {

            var result = await GetById(objs.RegimeId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {
                    result.RegimeId = objs.RegimeId;

                    result.Code = objs.Code;

                    result.Libelle = objs.Libelle;



                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Regime>> Search(String name)
        {

            IQueryable<Regime> query = appDbContext.Regimes;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Regime> GetByCriteria(string Libelle)
        {
            return await appDbContext.Regimes.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

    }
}
