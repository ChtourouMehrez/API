using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface ITypeContratRepository
    {
        public Task<IEnumerable<TypeContrat>> GetALL();
        public Task<TypeContrat> GetById(int id);
        public Task<TypeContrat> Add(TypeContrat obj);
        public Task<TypeContrat> Update(TypeContrat obj);
        public Task<TypeContrat> Delete(int Id);
        public Task<TypeContrat> GetByCriteria(string Criteria);
        public Task<IEnumerable<TypeContrat>> Search(string Criteria);

    }
}
