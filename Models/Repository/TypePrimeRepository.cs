using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace API.Models.Repository
{
#pragma warning disable CS0535 // 'QualificationRepository' n'implémente pas le membre d'interface 'IQualificationRepository.Delete(int)'
    public class TypePrimeRepository : ITypePrimeRepository
#pragma warning restore CS0535 // 'QualificationRepository' n'implémente pas le membre d'interface 'IQualificationRepository.Delete(int)'
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
            var result = await appDbContext.TypePrimes.FirstOrDefaultAsync(e => e.Id == id);
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

            return await appDbContext.TypePrimes.FirstOrDefaultAsync(e => e.Id == Id);
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

            var result = await GetById(typePrimes.Id);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != typePrimes)
                {
                    result.Id = typePrimes.Id;

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
