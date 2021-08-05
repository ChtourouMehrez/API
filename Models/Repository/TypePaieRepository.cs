using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace API.Models.Repository
{
#pragma warning disable CS0535 // 'QualificationRepository' n'implémente pas le membre d'interface 'IQualificationRepository.Delete(int)'
    public class TypePaieRepository : ITypePaieRepository
#pragma warning restore CS0535 // 'QualificationRepository' n'implémente pas le membre d'interface 'IQualificationRepository.Delete(int)'
    {
        private readonly AppDbContext appDbContext;

        public TypePaieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TypePaie> Add(TypePaie Obj)
        {
            var result = await appDbContext.TypePaies.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TypePaie> Delete(int id)
        {
            var result = await appDbContext.TypePaies.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {


                appDbContext.TypePaies.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TypePaie> GetById(int Id)
        {

            return await appDbContext.TypePaies.FirstOrDefaultAsync(e => e.Id == Id);
        }

        //public async Task<TypePaie> GetByCriteria(string Libelle)
        //{
        //    return await appDbContext.TypePaies.FirstOrDefaultAsync(e => e. == Libelle);

        //}

        public async Task<IEnumerable<TypePaie>> GetALL()
        {
            return await appDbContext.TypePaies.ToListAsync();
        }

        public async Task<TypePaie> Update(TypePaie obj)
        {

            var result = await GetById(obj.Id);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.Id = obj.Id;
                    result.PECNote = obj.PECNote;
                    result.PECPointage = obj.PECPointage;
                    result.PECPrime = obj.PECPrime;
                    result.codePaie = obj.codePaie;
                    result.AutreCalcule = obj.AutreCalcule;
                    result.Declarer = obj.Declarer;

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        //public async Task<IEnumerable<TypePaie>> Search(String name)
        //{

        //    IQueryable<TypePaie> query = appDbContext.TypePaies;
        //    if (!string.IsNullOrEmpty(name))
        //    {

        //        query = query.Where(e => e..Contains(name) || e.Libelle.Contains(name));
        //    }

        //    return await query.ToListAsync();
        //}



    }
}
