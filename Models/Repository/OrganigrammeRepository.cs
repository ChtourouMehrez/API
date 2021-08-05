using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace API.Models.Repository
{
    public class OrganigrammeRepository : IOrganigrammeRepository
    {
        private readonly AppDbContext appDbContext;

        public OrganigrammeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Organigramme> AddOrganigramme(Organigramme organigramme)
        {
            var result = await appDbContext.Organigrammes.AddAsync(organigramme);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Organigramme> DeleteOrganigramme(int Id)
        {
            var result = await appDbContext.Organigrammes.FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {


                appDbContext.Organigrammes.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Organigramme> GetOrganigramme(int Id)
        {

            return await appDbContext.Organigrammes.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<Organigramme> GetOrganigrammeByLibelle(string Libelle)
        {
            return await appDbContext.Organigrammes.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<Organigramme>> GetOrganigrammes()
        {
            return await appDbContext.Organigrammes.ToListAsync();
        }

        public async Task<Organigramme> UpdateOrganigramme(Organigramme organigramme)
        {

            var result = await GetOrganigramme(organigramme.Id);
            //await appDbContext.Organigrammes.Include(e => e.Departement).FirstOrDefaultAsync(e => e.OrganigrammeId == employe.OrganigrammeId);
            if (result != null)
            {
                if (result != organigramme)
                {
                    result.Id = organigramme.Id;

                    result.Code = organigramme.Code;

                    result.Libelle = organigramme.Libelle;

                    
                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Organigramme>> Search(String name )
        {

            IQueryable<Organigramme> query = appDbContext.Organigrammes;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }
            
            return await query.ToListAsync();
        }

     

    }
}
