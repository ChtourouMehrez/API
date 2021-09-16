using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IUtilisateurRepository
    {
        public Task<IEnumerable<Utilisateur>> GetALL();
        public Task<Utilisateur> GetById(int id);
        public Task<Utilisateur> Add(Utilisateur obj);
        public Task<Utilisateur> Update(Utilisateur obj);
        public Task<Utilisateur> Delete(int Id);
        public Task<Utilisateur> GetByCriteria(string Criteria);
        //public Task<IEnumerable<TypePaie>> Search(string Criteria);

    }
}
