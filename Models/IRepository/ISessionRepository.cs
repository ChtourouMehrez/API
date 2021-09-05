using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface ISessionRepository
    {
        public Task<IEnumerable<Personnel>> GetALLPersonnelBySessionId(int id);
        public Task<IEnumerable<Session>> GetALL();
        public Task<Session> GetById(int id);
        public Task<Session> Add(Session obj);
        public Task<Session> Update(Session obj);
        public Task<Session> Delete(int Id);
        public Task<Session> GetByCriteria(string Criteria);
        public Task<IEnumerable<Session>> Search(string Criteria);

    }
}
