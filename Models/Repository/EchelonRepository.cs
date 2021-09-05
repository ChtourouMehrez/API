using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{ 
    public class EchelonRepository : IEchelonRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public EchelonRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public EchelonRepository()
        {
        }

        public async Task<Echelon> Add(Echelon obj)
        {
            var result = await appDbContext.Echelons.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Echelon> Delete(int id)
        {
            var result = await appDbContext.Echelons.FirstOrDefaultAsync(e => e.EchelonId == id);
            if (result != null)
            {


                appDbContext.Echelons.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Echelon> GetById(int Id)
        {

            return await appDbContext.Echelons.FirstOrDefaultAsync(e => e.EchelonId == Id);
        }

     

        public async Task<IEnumerable<Echelon>> GetALL()
        {
            return await appDbContext.Echelons.ToListAsync();
        }

        public async Task<Echelon> Update(Echelon objs)
        {

            var result = await GetById(objs.EchelonId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {
                    result.EchelonId = objs.EchelonId;

                    result.Code = objs.Code;

                    result.Libelle = objs.Libelle;

                   

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Echelon>> Search(String name)
        {

            IQueryable<Echelon> query = appDbContext.Echelons;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Echelon> GetByCriteria(string Libelle)
        {
            return await appDbContext.Echelons.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

    }
}
