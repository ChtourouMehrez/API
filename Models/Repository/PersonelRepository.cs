



using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Models.Repository
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public PersonnelRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public PersonnelRepository()
        {
        }

        public async Task<Personnel> Add(Personnel obj)
        {
            var result = await appDbContext.Personnels.AddAsync(obj);

            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Personnel> Delete(int id)
        {
            var result = await appDbContext.Personnels.FirstOrDefaultAsync(e => e.PersonnelKey == id);
            if (result != null)
            {


                appDbContext.Personnels.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Personnel> GetById(int Id)
        {

            return await appDbContext.Personnels.FirstOrDefaultAsync(e => e.PersonnelKey == Id);
        }



        public async Task<IEnumerable<Personnel>> GetALL()
        {
            return await appDbContext.Personnels.ToListAsync();
        }
        public async Task<IEnumerable<Session>> GetALLSessionByPersonnelKey(int PersonnelKey)
        {
            return await appDbContext.Sessions.Include(e => e.PersonnelParSession).Where(e => e.SessionKey == PersonnelKey).ToListAsync();
        }
        public async Task<IEnumerable<PrimePersonnel>> GetALLPrimePersonnelByPersonnelKey(int PersonnelKey)
        {
            return await appDbContext.PrimePersonnels.Include(e => e.Personnel).Where(e => e.PersonnelKey == PersonnelKey).ToListAsync();
        }


        public async Task<Personnel> Update(Personnel objs)
        {

            var result = await GetById(objs.PersonnelKey);
            //await appDbContext.Qualifications.Include(e => e.Departement).FirstOrDefaultAsync(e => e.QualificationId == employe.QualificationId);
            if (result != null)
            {
                if (result != objs)
                {

                    result.PersonnelKey = objs.PersonnelKey;

                    result.Aarrondie = objs.Aarrondie;
                    result.Adresse = objs.Adresse;

                    result.Categorie = objs.Categorie;
                    result.CategorieId = objs.CategorieId;

                    result.CCB = objs.CCB;

                    result.ChargePatronale = objs.ChargePatronale;
                    result.ChargePatronaleId = objs.ChargePatronaleId;

                    result.ChefFamille = objs.ChefFamille;
                    result.CIN = objs.CIN;
                    result.CoefConge = objs.CoefConge;
                    result.ComplementSalaire = objs.ComplementSalaire;





                    result.DateCIN = objs.DateCIN;
                    result.DateCNSS = objs.DateCNSS;
                    result.DateDebut = objs.DateDebut;
                    result.DateDebutContrat = objs.DateDebutContrat;

                    result.DateEchange = objs.DateEchange;
                    result.DateEmbauche = objs.DateEmbauche;
                    result.DateFinContrat = objs.DateFinContrat;
                    result.DateNaissance = objs.DateNaissance;

                    result.DateSortie = objs.DateSortie;
                    result.Echelon = objs.Echelon;
                    result.EchelonId = objs.EchelonId;
                    result.EnActivite = objs.EnActivite;

                    result.EtatCivil = objs.EtatCivil;
                    result.Lieu = objs.Lieu;
                    result.MatriculeAssuranceSocial = objs.MatriculeAssuranceSocial;
                    result.MatriculePersonnel = objs.MatriculePersonnel;


                    result.ModeReglement = objs.ModeReglement;
                    result.ModeReglementId = objs.ModeReglementId;
                    result.Nationalite = objs.Nationalite;
                    result.Nature = objs.Nature;


                    result.NatureId = objs.NatureId;
                    result.NbreParentAcharge = objs.NbreParentAcharge;
                    result.Nom = objs.Nom;



                    result.NonRegle = objs.NonRegle;
                    result.NumeroCNSS = objs.NumeroCNSS;
                    result.NumeroSession = objs.NumeroSession;
                    result.Observation = objs.Observation;

                    result.Organigramme = objs.Organigramme;
                    result.OrganigrammeId = objs.OrganigrammeId;
                    result.ParentCharge = objs.ParentCharge;



                    result.PersonnelKey = objs.PersonnelKey;
                    result.Prenom = objs.Prenom;
                    result.Qualification = objs.Qualification;
                    result.QualificationId = objs.QualificationId;


                    result.Regime = objs.Regime;
                    result.RegimeId = objs.RegimeId;
                    result.SalaireBase = objs.SalaireBase;



                    result.SessionKey = objs.SessionKey;
                    result.sexe = objs.sexe;
                    result.SoumisImpot = objs.SoumisImpot;
                    result.STC = objs.STC;
                    result.TypeContrat = objs.TypeContrat;
                    result.TypeContratId = objs.TypeContratId;
                    result.NumeroTel = objs.NumeroTel;

                    result.Email = objs.Email;
                    result.PrimePersonnels = objs.PrimePersonnels;
                    await appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }


        public async Task<IEnumerable<Personnel>> Search(String name)
        {

            IQueryable<Personnel> query = appDbContext.Personnels;
            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.NomPrenom.Contains(name) || e.Adresse.Contains(name) || e.MatriculeAssuranceSocial.ToString().Contains(name) || e.MatriculePersonnel.Contains(name) || e.CIN.ToString().Contains(name) || e.DateDebutContrat == Convert.ToDateTime(name) || e.DateFinContrat == Convert.ToDateTime(name) || e.NumeroTel.Contains(name) || e.Email.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Personnel> GetByCriteria(string Libelle)
        {
            return await appDbContext.Personnels.FirstOrDefaultAsync(e => e.NomPrenom == Libelle);

        }

    }
}
