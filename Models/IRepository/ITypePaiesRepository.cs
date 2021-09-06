using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface ITypePaiesRepository
    {
        public Task<IEnumerable<TypePaies>> GetALL();
        public Task<TypePaies> GetById(int id);
        public Task<TypePaies> Add(TypePaies obj);
        public Task<TypePaies> Update(TypePaies obj);
        public Task<TypePaies> Delete(int Id);
       public Task<TypePaies> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
