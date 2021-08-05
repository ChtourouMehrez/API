using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace API.Models.Repository
{
    public interface ITypePaieRepository
    {
        public Task<IEnumerable<TypePaie>> GetALL();
        public Task<TypePaie> GetById(int id);
        public Task<TypePaie> Add(TypePaie obj);
        public Task<TypePaie> Update(TypePaie obj);
        public Task<TypePaie> Delete(int Id);
        //public Task<TypePaie> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
