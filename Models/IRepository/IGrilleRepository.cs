using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IGrilleRepository
    {
        public Task<IEnumerable<Grille>> GetALL();
        public Task<Grille> GetById(int id);
        public Task<Grille> Add(Grille obj);
        public Task<Grille> Update(Grille obj);
        public Task<Grille> Delete(int Id);
        public Task<Grille> GetByCriteria(string Criteria);
        public Task<IEnumerable<Grille>> Search(string Criteria);

    }
}
