using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface INatureRepository
    {
        public Task<IEnumerable<Nature>> GetALL();
        public Task<Nature> GetById(int id);
        public Task<Nature> Add(Nature obj);
        public Task<Nature> Update(Nature obj);
        public Task<Nature> Delete(int Id);
        public Task<Nature> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
