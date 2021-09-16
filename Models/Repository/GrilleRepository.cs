using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class GrilleRepository : IGrilleRepository
    {
        private readonly AppDbContext appDbContext;

        public GrilleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Grille> Add(Grille Obj)
        {
            var result = await appDbContext.Grilles.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Grille> Delete(int id)
        {
            var result = await appDbContext.Grilles.FirstOrDefaultAsync(e => e.GrilleId == id);
            if (result != null)
            {


                appDbContext.Grilles.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Grille> GetById(int Id)
        {

            return await appDbContext.Grilles.FirstOrDefaultAsync(e => e.GrilleId == Id);
        }

        public async Task<Grille> GetByCriteria(string Libelle)
        {
            return await appDbContext.Grilles.FirstOrDefaultAsync(e => e.QualificationId == 1);

        }

        public async Task<IEnumerable<Grille>> GetALL()
        {


            return await   appDbContext.Grilles.Include(e => e.Echelon).Include(e => e.Categorie).Include(e => e.Qualification).ToListAsync();

        }

        public async Task<Grille> Update(Grille obj)
        {

            var result = await GetById(obj.GrilleId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.GrilleId = obj.GrilleId;

                    result.EchelonId = obj.EchelonId;


                    result.CategorieId = obj.CategorieId;

                    result.QualificationId = obj.QualificationId;
                    result.Salaire = obj.Salaire;
                    result.NbreMoisAnciente = obj.NbreMoisAnciente;

                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Grille>> Search(String name)
        {

            IQueryable<Grille> query = appDbContext.Grilles;
            if (!string.IsNullOrEmpty(name))
            {

              //  query = query.Where(e => e.sa.Contains(name) || e.Echelon.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
