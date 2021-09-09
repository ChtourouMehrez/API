using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext appDbContext;

        public SessionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Session> Add(Session Obj)
        {
            Obj.DateCloture = Convert.ToDateTime("31/01/2018");
            var result = await appDbContext.Sessions.AddAsync(Obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Session> Delete(int id)
        {
            var result = await appDbContext.Sessions.FirstOrDefaultAsync(e => e.SessionKey == id);
            if (result != null)
            {


                appDbContext.Sessions.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Session> GetById(int Id)
        {

            return await appDbContext.Sessions.FirstOrDefaultAsync(e => e.SessionKey == Id);
        }

        public async Task<Session> GetByCriteria(string Designation)
        {
            return await appDbContext.Sessions.FirstOrDefaultAsync(e => e.Designation == Designation);

        }

        public async Task<IEnumerable<Session>> GetALL()
        {
            return await appDbContext.Sessions.Include(e => e.TypePaies).ToListAsync();
        }
        public async Task<IEnumerable<Personnel>> GetALLPersonnelBySessionId(int SessionKey)
        {
            return await appDbContext.Personnels.Where(e => e.SessionKey == SessionKey).ToListAsync();
        }
        public async Task<Session> Update(Session obj)
        {

            var result = await GetById(obj.SessionKey);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != obj)
                {
                    result.SessionKey = obj.SessionKey;


                    result.Designation = obj.Designation;

                    result.Cloturer = obj.Cloturer;

                    result.DateCloture = obj.DateCloture;

                    result.DateDebutSession = obj.DateDebutSession;


                    result.DateFinSession = obj.DateFinSession;

                    result.DateOuverture = obj.DateOuverture;
                    result.Exercice = obj.Exercice;
                    result.MoisSession = obj.MoisSession;

                    result.Trimestre = obj.Trimestre;
                    result.TypePaies = obj.TypePaies;
                    result.TypePaiesId = obj.TypePaiesId;
                    result.UserCloture = obj.UserCloture;
                    result.UserOuverture = obj.UserOuverture;

                    result.NumeroSession = obj.NumeroSession;






                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Session>> Search(String name)
        {

            IQueryable<Session> query = appDbContext.Sessions;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.NumeroSession.Contains(name) || e.Designation.Contains(name));
            }

            return await query.ToListAsync();
        }



    }
}
