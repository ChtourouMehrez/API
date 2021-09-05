using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IEchelonRepository
    {
        public Task<IEnumerable<Echelon>> GetALL();
        public Task<Echelon> GetById(int id);
        public Task<Echelon> Add(Echelon obj);
        public Task<Echelon> Update(Echelon obj);
        public Task<Echelon> Delete(int Id);
        public Task<Echelon> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
