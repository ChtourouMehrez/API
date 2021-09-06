using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IChargePatronaleRepository
    {
        public Task<IEnumerable<ChargePatronale>> GetALL();
        public Task<ChargePatronale> GetById(int id);
        public Task<ChargePatronale> Add(ChargePatronale obj);
        public Task<ChargePatronale> Update(ChargePatronale obj);
        public Task<ChargePatronale> Delete(int Id);
        public Task<ChargePatronale> GetByCriteria(string Criteria);
        public Task<IEnumerable<ChargePatronale>> Search(string Criteria);

    }
}
