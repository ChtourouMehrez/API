using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace API.Models.Repository
{
    public interface IHeureSuplementaireRepository
    {
        public Task<IEnumerable<HeureSupplementaire>> GetALL();
        public Task<HeureSupplementaire> GetById(int id);
        public Task<HeureSupplementaire> Add(HeureSupplementaire obj);
        public Task<HeureSupplementaire> Update(HeureSupplementaire obj);
        public Task<HeureSupplementaire> Delete(int Id);
        public Task<HeureSupplementaire> GetByCriteria(string Criteria);
        public Task<IEnumerable<HeureSupplementaire>> Search(string Criteria);
         
    }
}
