using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class NatureRepository : INatureRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public NatureRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public NatureRepository()
        {
        }

        public async Task<Nature> Add(Nature obj)
        {
            var result = await appDbContext.Natures.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Nature> Delete(int id)
        {
            var result = await appDbContext.Natures.FirstOrDefaultAsync(e => e.NatureId == id);
            if (result != null)
            {


                appDbContext.Natures.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Nature> GetById(int Id)
        {

            return await appDbContext.Natures.FirstOrDefaultAsync(e => e.NatureId == Id);
        }



        public async Task<IEnumerable<Nature>> GetALL()
        {
            return await appDbContext.Natures.ToListAsync();
        }

        public async Task<Nature> Update(Nature objs)
        {

            var result = await GetById(objs.NatureId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {
                    result.NatureId = objs.NatureId;

                    result.Code = objs.Code;

                    result.Libelle = objs.Libelle;



                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Nature>> Search(String name)
        {

            IQueryable<Nature> query = appDbContext.Natures;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Nature> GetByCriteria(string Libelle)
        {
            return await appDbContext.Natures.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

    }
}
