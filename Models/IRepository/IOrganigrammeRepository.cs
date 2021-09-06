using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IOrganigrammeRepository
    {
        public Task<IEnumerable<Organigramme>> GetOrganigrammes();
        public Task<Organigramme> GetOrganigramme(int organigrammeId);
        public Task<Organigramme> AddOrganigramme(Organigramme organigramme);
        public Task<Organigramme> UpdateOrganigramme(Organigramme organigramme);
        public Task<Organigramme> DeleteOrganigramme(int Id);
        public Task<Organigramme> GetOrganigrammeByLibelle(String email);
        public Task<IEnumerable<Organigramme>> Search(string name);

    }
}
