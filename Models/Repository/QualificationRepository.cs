using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace API.Models.Repository
{
#pragma warning disable CS0535 // 'QualificationRepository' n'implémente pas le membre d'interface 'IQualificationRepository.Delete(int)'
    public class QualificationRepository : IQualificationRepository
#pragma warning restore CS0535 // 'QualificationRepository' n'implémente pas le membre d'interface 'IQualificationRepository.Delete(int)'
    {
        private readonly AppDbContext appDbContext;

        public QualificationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Qualification> Add(Qualification qualification)
        {
            var result = await appDbContext.Qualifications.AddAsync(qualification);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Qualification> Delete(int id)
        {
            var result = await appDbContext.Qualifications.FirstOrDefaultAsync(e => e.QualificationId == id);
            if (result != null)
            {


                appDbContext.Qualifications.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Qualification> GetById(int Id)
        {

            return await appDbContext.Qualifications.FirstOrDefaultAsync(e => e.QualificationId == Id);
        }

        public async Task<Qualification> GetByCriteria(string Libelle)
        {
            return await appDbContext.Qualifications.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<Qualification>> GetALL()
        {
            return await appDbContext.Qualifications.ToListAsync();
        }

        public async Task<Qualification> Update(Qualification qualification)
        {

            var result = await GetById(qualification.QualificationId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != qualification)
                {
                    result.QualificationId = qualification.QualificationId;

                    result.CodeQualification = qualification.CodeQualification;

                    result.Libelle = qualification.Libelle;


                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Qualification>> Search(String name)
        {

            IQueryable<Qualification> query = appDbContext.Qualifications;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
