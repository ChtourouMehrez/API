using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public CategorieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public CategorieRepository()
        {
        }

        public async Task<Categorie> Add(Categorie obj)
        {
            var result = await appDbContext.Categories.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Categorie> Delete(int id)
        {
            var result = await appDbContext.Categories.FirstOrDefaultAsync(e => e.CategorieId == id);
            if (result != null)
            {


                appDbContext.Categories.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Categorie> GetById(int Id)
        {

            return await appDbContext.Categories.FirstOrDefaultAsync(e => e.CategorieId == Id);
        }



        public async Task<IEnumerable<Categorie>> GetALL()
        {
            return await appDbContext.Categories.ToListAsync();
        }

        public async Task<Categorie> Update(Categorie objs)
        {

            var result = await GetById(objs.CategorieId);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {
                    result.CategorieId = objs.CategorieId;

                    result.Code = objs.Code;

                    result.Libelle = objs.Libelle;



                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Categorie>> Search(String name)
        {

            IQueryable<Categorie> query = appDbContext.Categories;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.Libelle.Contains(name) || e.Libelle.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Categorie> GetByCriteria(string Libelle)
        {
            return await appDbContext.Categories.FirstOrDefaultAsync(e => e.Libelle == Libelle);

        }

    }
}
