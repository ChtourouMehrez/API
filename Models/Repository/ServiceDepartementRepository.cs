using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class ServiceDepartementRepository : IServiceDepartementRepository
    {
        private readonly AppDbContext appDbContext;

        public ServiceDepartementRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceDepartement> Add(ServiceDepartement Obj)
        {
            var result = await appDbContext.ServiceDepartements.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ServiceDepartement> Delete(int id)
        {
            var result = await appDbContext.ServiceDepartements.FirstOrDefaultAsync(e => e.ServiceDepartementId == id);
            if (result != null)
            {


                appDbContext.ServiceDepartements.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ServiceDepartement> GetById(int Id)
        {

            return await appDbContext.ServiceDepartements.FirstOrDefaultAsync(e => e.ServiceDepartementId == Id);
        }

        public async Task<ServiceDepartement> GetByCriteria(string Libelle)
        {
            return await appDbContext.ServiceDepartements.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<ServiceDepartement>> GetALL()
        {
            return await appDbContext.ServiceDepartements.ToListAsync();
        }

        public async Task<ServiceDepartement> Update(ServiceDepartement obj)
        {

            var result = await GetById(obj.ServiceDepartementId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.ServiceDepartementId = obj.ServiceDepartementId;


                    result.Libelle = obj.Libelle;



                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<ServiceDepartement>> Search(String name)
        {

            IQueryable<ServiceDepartement> query = appDbContext.ServiceDepartements;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
