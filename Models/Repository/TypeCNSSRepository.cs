using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class TypeCNSSRepository : ITypeCNSSRepository
    {
        private readonly AppDbContext appDbContext;

        public TypeCNSSRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TypeCNSS> Add(TypeCNSS Obj)
        {
            var result = await appDbContext.TypeCNSSs.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TypeCNSS> Delete(int id)
        {
            var result = await appDbContext.TypeCNSSs.FirstOrDefaultAsync(e => e.TypeCNSSId == id);
            if (result != null)
            {


                appDbContext.TypeCNSSs.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TypeCNSS> GetById(int Id)
        {

            return await appDbContext.TypeCNSSs.FirstOrDefaultAsync(e => e.TypeCNSSId == Id);
        }

        public async Task<TypeCNSS> GetByCriteria(string Libelle)
        {
            return await appDbContext.TypeCNSSs.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<TypeCNSS>> GetALL()
        {
            return await appDbContext.TypeCNSSs.ToListAsync();
        }

        public async Task<TypeCNSS> Update(TypeCNSS obj)
        {

            var result = await GetById(obj.TypeCNSSId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.TypeCNSSId = obj.TypeCNSSId;

                    result.Libelle = obj.Libelle;

                    result.Code = obj.Code;


                    result.Taux  = obj.Taux;

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<TypeCNSS>> Search(String name)
        {

            IQueryable<TypeCNSS> query = appDbContext.TypeCNSSs;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
