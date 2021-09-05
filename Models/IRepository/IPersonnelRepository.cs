using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IPersonnelRepository
    {
        public Task<IEnumerable<PrimePersonnel>> GetALLPrimePersonnelByPersonnelKey(int PersonnelKey);
        public Task<IEnumerable<Session>> GetALLSessionByPersonnelKey(int PersonnelKey);
        public Task<IEnumerable<Personnel>> GetALL();
        public Task<Personnel> GetById(int id);
        public Task<Personnel> Add(Personnel obj);
        public Task<Personnel> Update(Personnel obj);
        public Task<Personnel> Delete(int Id);
        public Task<Personnel> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
