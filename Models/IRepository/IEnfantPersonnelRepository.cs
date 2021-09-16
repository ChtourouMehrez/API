using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IEnfantPersonnelRepository
    {
        public Task<IEnumerable<EnfantPersonnel>> GetALL();
        public Task<EnfantPersonnel> GetById(int id);
        public Task<EnfantPersonnel> Add(EnfantPersonnel obj);
        public Task<EnfantPersonnel> Update(EnfantPersonnel obj);
        public Task<EnfantPersonnel> Delete(int Id);
        public Task<EnfantPersonnel> GetByCriteria(string Criteria);
        public Task<IEnumerable<EnfantPersonnel>> Search(string Criteria);

    }
}
