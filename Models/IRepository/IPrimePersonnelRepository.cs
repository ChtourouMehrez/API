using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IPrimePersonnelRepository
    {
        public Task<IEnumerable<PrimePersonnel>> GetALL();
        public Task<PrimePersonnel> GetById(int id);
        public Task<PrimePersonnel> Add(PrimePersonnel obj);
        public Task<PrimePersonnel> Update(PrimePersonnel obj);
        public Task<PrimePersonnel> Delete(int Id);
        public Task<PrimePersonnel> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
