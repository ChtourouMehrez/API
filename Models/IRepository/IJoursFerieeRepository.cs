using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IJoursFerieRepository
    {
        public Task<IEnumerable<JoursFerie>> GetALL();
        public Task<JoursFerie> GetById(int id);
        public Task<JoursFerie> Add(JoursFerie obj);
        public Task<JoursFerie> Update(JoursFerie obj);
        public Task<JoursFerie> Delete(int Id);
        public Task<JoursFerie> GetByCriteria(string Criteria);
        public Task<IEnumerable<JoursFerie>> Search(string Criteria);

    }
}
