using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class ModeReglementRepository : IModeReglementRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public ModeReglementRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public ModeReglementRepository()
        {
        }

        public async Task<ModeReglement> Add(ModeReglement obj)
        {
            var result = await appDbContext.ModeReglements.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ModeReglement> Delete(int id)
        {
            var result = await appDbContext.ModeReglements.FirstOrDefaultAsync(e => e.ModeReglementId == id);
            if (result != null)
            {


                appDbContext.ModeReglements.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ModeReglement> GetById(int Id)
        {

            return await appDbContext.ModeReglements.FirstOrDefaultAsync(e => e.ModeReglementId == Id);
        }



        public async Task<IEnumerable<ModeReglement>> GetALL()
        {
            return await appDbContext.ModeReglements.ToListAsync();
        }

        public async Task<ModeReglement> Update(ModeReglement objs)
        {

            var result = await GetById(objs.ModeReglementId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {
                    result.ModeReglementId = objs.ModeReglementId;

                    result.Code = objs.Code;

                    result.Libelle = objs.Libelle;



                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<ModeReglement>> Search(String name)
        {

            IQueryable<ModeReglement> query = appDbContext.ModeReglements;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<ModeReglement> GetByCriteria(string Libelle)
        {
            return await appDbContext.ModeReglements.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

    }
}
