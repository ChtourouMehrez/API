using API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrillesController : ControllerBase
    {
        private readonly IGrilleRepository repository;
        private readonly IRegimeRepository repositoryRegime;
        private readonly ICategorieRepository repositoryCategorie;
        private readonly IEchelonRepository repositoryEchelon;
        public GrillesController(IGrilleRepository repository, ICategorieRepository repositoryCategorie, IRegimeRepository repositoryRegime, IEchelonRepository repositoryEchelon)
        {
            this.repositoryCategorie = repositoryCategorie;
            this.repositoryRegime = repositoryRegime;
            this.repositoryEchelon = repositoryEchelon;

            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await repository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Grille>> GetById(int id)
        {
            try
            {
                var result = await repository.GetById(id);
                if
                (result == null)
                    return NotFound();
                return result;
            }
            catch
            (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Grille>> Create([FromBody] Grille obj)
        {
            try
            {

                if
                (obj == null)
                {
                    return BadRequest();

                }
                else
                {
                    var org = await repository.GetById(obj.GrilleId);
                    if (org == null)
                    {
                        //obj.Regime = new Regime();
                        //obj.Categorie = new Categorie();
                        //obj.Echelon = new Echelon();

                        obj.Regime = await repositoryRegime.GetById(obj.RegimeId);
                        obj.Categorie = await repositoryCategorie.GetById(obj.CategorieId);
                        obj.Echelon = await repositoryEchelon.GetById(obj.EchelonId);

                        var created = await repository.Add(obj);
                        return CreatedAtAction(nameof(GetById), new { id = created.GrilleId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("Id", "Id il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Grilles ");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Grille>> Update(int id, Grille objet)
        {

            try
            {

                if (id != objet.GrilleId)
                    return BadRequest("Type grille ID mismatch");
                var objetToUpdate = await repository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"type grille with id ={id} not Found");
                return await repository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Type Contrat data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Grille>> Delete(int id)
        {
            try
            {
                var objetToDelete = await repository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Type grille with Id = {id} not found");
                }

                return await repository.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Grille>>> Search(string name)
        {
            try
            {
                var result = await repository.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Type Contrat data");
            }



        }



    }
}
