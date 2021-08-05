using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace API.Models.Repository
{ 
    public class TypeContratRepository : ITypeContratRepository 
    {
        private readonly AppDbContext appDbContext;

        public TypeContratRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TypeContrat> Add(TypeContrat Obj)
        {
            var result = await appDbContext.TypeContrats.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TypeContrat> Delete(int id)
        {
            var result = await appDbContext.TypeContrats.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {


                appDbContext.TypeContrats.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TypeContrat> GetById(int Id)
        {

            return await appDbContext.TypeContrats.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<TypeContrat> GetByCriteria(string Libelle)
        {
            return await appDbContext.TypeContrats.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<TypeContrat>> GetALL()
        {
            return await appDbContext.TypeContrats.ToListAsync();
        }

        public async Task<TypeContrat> Update(TypeContrat obj)
        {

            var result = await GetById(obj.Id);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.Id = obj.Id;

                    result.CodeTypeContrat = obj.CodeTypeContrat;

                    result.Libelle = obj.Libelle;

                    result.CompterAnciente = obj.CompterAnciente;
                   

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<TypeContrat>> Search(String name)
        {

            IQueryable<TypeContrat> query = appDbContext.TypeContrats;
            if (!string.IsNullOrEmpty(name))
            {
                
                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
