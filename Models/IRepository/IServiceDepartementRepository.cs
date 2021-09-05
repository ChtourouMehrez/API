using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IServiceDepartementRepository
    {
        public Task<IEnumerable<ServiceDepartement>> GetALL();
        public Task<ServiceDepartement> GetById(int id);
        public Task<ServiceDepartement> Add(ServiceDepartement obj);
        public Task<ServiceDepartement> Update(ServiceDepartement obj);
        public Task<ServiceDepartement> Delete(int Id);
        public Task<ServiceDepartement> GetByCriteria(string Criteria);
        public Task<IEnumerable<ServiceDepartement>> Search(string Criteria);

    }
}
