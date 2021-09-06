using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IModeReglementRepository
    {
        public Task<IEnumerable<ModeReglement>> GetALL();
        public Task<ModeReglement> GetById(int id);
        public Task<ModeReglement> Add(ModeReglement obj);
        public Task<ModeReglement> Update(ModeReglement obj);
        public Task<ModeReglement> Delete(int Id);
        public Task<ModeReglement> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
