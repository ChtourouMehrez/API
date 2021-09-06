using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IRegimeRepository
    {
        public Task<IEnumerable<Regime>> GetALL();
        public Task<Regime> GetById(int id);
        public Task<Regime> Add(Regime obj);
        public Task<Regime> Update(Regime obj);
        public Task<Regime> Delete(int Id);
        public Task<Regime> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
