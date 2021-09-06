using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface ITypeCNSSRepository
    {
        public Task<IEnumerable<TypeCNSS>> GetALL();
        public Task<TypeCNSS> GetById(int id);
        public Task<TypeCNSS> Add(TypeCNSS obj);
        public Task<TypeCNSS> Update(TypeCNSS obj);
        public Task<TypeCNSS> Delete(int Id);
        public Task<TypeCNSS> GetByCriteria(string Criteria);
        public Task<IEnumerable<TypeCNSS>> Search(string Criteria);

    }
}
