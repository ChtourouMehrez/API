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
    public class JoursFeriesController : ControllerBase
    {
        private readonly IJoursFerieRepository repository;

        public JoursFeriesController(IJoursFerieRepository repository)
        {

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
        public async Task<ActionResult<JoursFerie>> GetById(int id)
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
        public async Task<ActionResult<JoursFerie>> Create([FromBody] JoursFerie obj)
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
                    var org = await repository.GetByCriteria(obj.Libelle);
                    if (org == null)
                    {

                        var created = await repository.Add(obj);
                        return CreatedAtAction(nameof(GetById), new { id = created.JoursFerieId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("Libelle", "Libelle il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Jours Ferie");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<JoursFerie>> Update(int id, JoursFerie objet)
        {

            try
            {

                if (id != objet.JoursFerieId)
                    return BadRequest("Jours Ferie ID mismatch");
                var objetToUpdate = await repository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Jours Ferie with id ={id} not Found");
                return await repository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Jours Ferie data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<JoursFerie>> Delete(int id)
        {
            try
            {
                var objetToDelete = await repository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Jours Ferie with Id = {id} not found");
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
        public async Task<ActionResult<IEnumerable<JoursFerie>>> Search(string name)
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

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Jours Ferie data");
            }



        }



    }
}
