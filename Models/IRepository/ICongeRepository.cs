using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface ICongeRepository
    {
        public Task<IEnumerable<Conge>> GetALL();
        public Task<Conge> GetById(int id);
        public Task<Conge> Add(Conge obj);
        public Task<Conge> Update(Conge obj);
        public Task<Conge> Delete(int Id);
        public Task<Conge> GetByCriteria(string Criteria);
        public Task<IEnumerable<Conge>> Search(string Criteria);

    }
}
