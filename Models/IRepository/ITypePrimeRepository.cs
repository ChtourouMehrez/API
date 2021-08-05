using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace API.Models.Repository
{
    public interface ITypePrimeRepository
    {
        public Task<IEnumerable<TypePrime>> GetALL();
        public Task<TypePrime> GetById(int id);
        public Task<TypePrime> Add(TypePrime typePrime);
        public Task<TypePrime> Update(TypePrime typePrime);
        public Task<TypePrime> Delete(int Id);
        public Task<TypePrime> GetByCriteria(string Criteria);
        public Task<IEnumerable<TypePrime>> Search(string Criteria);
         
    }
}
