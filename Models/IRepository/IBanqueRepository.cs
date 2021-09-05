using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IBanqueRepository
    {
        public Task<IEnumerable<Banque>> GetALL();
        public Task<Banque> GetById(int id);
        public Task<Banque> Add(Banque obj);
        public Task<Banque> Update(Banque obj);
        public Task<Banque> Delete(int Id);
        public Task<Banque> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
