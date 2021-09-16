using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class EnfantPersonnelRepository : IEnfantPersonnelRepository
    {
        private readonly AppDbContext appDbContext;

        public EnfantPersonnelRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<EnfantPersonnel> Add(EnfantPersonnel Obj)
        {
            var result = await appDbContext.EnfantPersonnels.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EnfantPersonnel> Delete(int id)
        {
            var result = await appDbContext.EnfantPersonnels.FirstOrDefaultAsync(e => e.EnfantPersonnelId == id);
            if (result != null)
            {


                appDbContext.EnfantPersonnels.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<EnfantPersonnel> GetById(int Id)
        {

            return await appDbContext.EnfantPersonnels.FirstOrDefaultAsync(e => e.EnfantPersonnelId == Id);
        }

        public async Task<EnfantPersonnel> GetByCriteria(string Libelle)
        {
            return await appDbContext.EnfantPersonnels.FirstOrDefaultAsync(e => e.NomPrenom == Libelle);

        }

        public async Task<IEnumerable<EnfantPersonnel>> GetALL()
        {
            return await appDbContext.EnfantPersonnels.ToListAsync();
        }

        public async Task<EnfantPersonnel> Update(EnfantPersonnel obj)
        {

            var result = await GetById(obj.EnfantPersonnelId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.EnfantPersonnelId = obj.EnfantPersonnelId;

                    result.DateNaissance = obj.DateNaissance;

                    result.EnCharge = obj.EnCharge;

                    result.EnfantPersonnelId = obj.EnfantPersonnelId;
                    result.EtudiantNonBoursier = obj.EtudiantNonBoursier;
                    result.Hendicape = obj.Hendicape;
                    result.NomPrenom = obj.NomPrenom;
                    result.Personnel = obj.Personnel;
                    result.PersonnelKey = obj.PersonnelKey;
                    result.Session = obj.Session;
                    result.SessionKey = obj.SessionKey;
                    result.Situation = obj.Situation;

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<EnfantPersonnel>> Search(String name)
        {

            IQueryable<EnfantPersonnel> query = appDbContext.EnfantPersonnels;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.NomPrenom.Contains(name) || e.NomPrenom.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
