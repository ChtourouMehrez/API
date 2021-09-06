using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IQualificationRepository
    {
        public Task<IEnumerable<Qualification>> GetALL();
        public Task<Qualification> GetById(int qualificationId);
        public Task<Qualification> Add(Qualification qualification);
        public Task<Qualification> Update(Qualification qualification);
        public Task<Qualification> Delete(int Id);
        public Task<Qualification> GetByCriteria(string Criteria);
        public Task<IEnumerable<Qualification>> Search(string Criteria);

    }
}
