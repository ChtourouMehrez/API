using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Repository;
using Models;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeContratsController : ControllerBase
    {
        private readonly ITypeContratRepository repository;

        public TypeContratsController(ITypeContratRepository repository)
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
        public async Task<ActionResult<TypeContrat>> GetById(int id)
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
        public async Task<ActionResult<TypeContrat>> Create([FromBody] TypeContrat obj)
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
                        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Type Prime");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<TypeContrat>> Update(int id, TypeContrat objet)
        {

            try
            {

                if (id != objet.Id)
                    return BadRequest("Type Prime ID mismatch");
                var objetToUpdate = await repository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"type Prime with id ={id} not Found");
                return await repository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Type Contrat data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TypeContrat>> Delete(int id)
        {
            try
            {
                var objetToDelete = await repository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Type Contrat with Id = {id} not found");
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
        public async Task<ActionResult<IEnumerable<TypeContrat>>> Search(string name)
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
