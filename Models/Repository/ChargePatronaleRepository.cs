using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class ChargePatronaleRepository : IChargePatronaleRepository
    {
        private readonly AppDbContext appDbContext;

        public ChargePatronaleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ChargePatronale> Add(ChargePatronale Obj)
        {
            var result = await appDbContext.ChargePatronales.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ChargePatronale> Delete(int id)
        {
            var result = await appDbContext.ChargePatronales.FirstOrDefaultAsync(e => e.ChargePatronaleId == id);
            if (result != null)
            {


                appDbContext.ChargePatronales.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ChargePatronale> GetById(int Id)
        {

            return await appDbContext.ChargePatronales.FirstOrDefaultAsync(e => e.ChargePatronaleId == Id);
        }

        public async Task<ChargePatronale> GetByCriteria(string Libelle)
        {
            return await appDbContext.ChargePatronales.FirstOrDefaultAsync(e => e.CodeChargePatronale == Libelle);

        }

        public async Task<IEnumerable<ChargePatronale>> GetALL()
        {
            return await appDbContext.ChargePatronales.ToListAsync();
        }

        public async Task<ChargePatronale> Update(ChargePatronale obj)
        {

            var result = await GetById(obj.ChargePatronaleId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.ChargePatronaleId = obj.ChargePatronaleId;

                    result.CodeChargePatronale = obj.CodeChargePatronale;

                    result.CodeExpoloitation = obj.CodeExpoloitation;

                    result.Taux = obj.Taux;


                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<ChargePatronale>> Search(String name)
        {

            IQueryable<ChargePatronale> query = appDbContext.ChargePatronales;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.CodeChargePatronale.Contains(name) || e.CodeExpoloitation.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
