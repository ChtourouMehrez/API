using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{ 
    public class TypePrimeRepository : ITypePrimeRepository 
    {
        private readonly AppDbContext appDbContext;

        public TypePrimeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TypePrime> Add(TypePrime typePrime)
        {
            var result = await appDbContext.TypePrimes.AddAsync(typePrime);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TypePrime> Delete(int id)
        {
            var result = await appDbContext.TypePrimes.FirstOrDefaultAsync(e => e.TypePrimeId == id);
            if (result != null)
            {


                appDbContext.TypePrimes.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TypePrime> GetById(int Id)
        {

            return await appDbContext.TypePrimes.FirstOrDefaultAsync(e => e.TypePrimeId == Id);
        }

        public async Task<TypePrime> GetByCriteria(string Libelle)
        {
            return await appDbContext.TypePrimes.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

        public async Task<IEnumerable<TypePrime>> GetALL()
        {
            return await appDbContext.TypePrimes.ToListAsync();
        }

        public async Task<TypePrime> Update(TypePrime typePrimes)
        {

            var result = await GetById(typePrimes.TypePrimeId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != typePrimes)
                {
                    result.TypePrimeId = typePrimes.TypePrimeId;

                    result.CodePrime = typePrimes.CodePrime;

                    result.Libelle = typePrimes.Libelle;

                    result.Cotisable = typePrimes.Cotisable;
                    result.Imposable = typePrimes.Imposable;
                    result.PointageNormal = typePrimes.PointageNormal;
                    result.PriseConsideration = typePrimes.PriseConsideration;

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<TypePrime>> Search(String name)
        {

            IQueryable<TypePrime> query = appDbContext.TypePrimes;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
