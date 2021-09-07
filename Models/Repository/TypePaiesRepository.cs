using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class TypePaiesRepository : ITypePaiesRepository
    {
        private readonly AppDbContext appDbContext;

        public TypePaiesRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TypePaies> Add(TypePaies Obj)
        {
            var result = await appDbContext.TypePaie.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TypePaies> Delete(int id)
        {
            var result = await appDbContext.TypePaie.FirstOrDefaultAsync(e => e.TypePaiesId == id);
            if (result != null)
            {


                appDbContext.TypePaie.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TypePaies> GetById(int Id)
        {

            return await appDbContext.TypePaie.FirstOrDefaultAsync(e => e.TypePaiesId == Id);
        }

        public async Task<TypePaies> GetByCriteria(string CodePaie)
        {
            return await appDbContext.TypePaie.FirstOrDefaultAsync(e => e.CodePaie == CodePaie);

        }

        public async Task<IEnumerable<TypePaies>> GetALL()
        {
            return await appDbContext.TypePaie.ToListAsync();
        }

        public async Task<TypePaies> Update(TypePaies obj)
        {

            var result = await GetById(obj.TypePaiesId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.TypePaiesId = obj.TypePaiesId;
                    result.CodePaie = obj.CodePaie;
                    result.Libelle = obj.Libelle;
                    result.Declarer = obj.Declarer;
                    result.PECPrime = obj.PECPrime;
                    result.PECNote = obj.PECNote;
                    result.AutreCalcule = obj.AutreCalcule;
                    result.PECPointage = obj.PECPointage;

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
