using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface ICategorieRepository
    {
        public Task<IEnumerable<Categorie>> GetALL();
        public Task<Categorie> GetById(int id);
        public Task<Categorie> Add(Categorie obj);
        public Task<Categorie> Update(Categorie obj);
        public Task<Categorie> Delete(int Id);
        public Task<Categorie> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
