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
    public class TypePrimesController : ControllerBase
    {
        private readonly ITypePrimeRepository typePrimeRepository;

        public TypePrimesController(ITypePrimeRepository typePrimeRepository)
        {

            this.typePrimeRepository = typePrimeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await typePrimeRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<TypePrime>> GetById(int id)
        {
            try
            {
                var result = await typePrimeRepository.GetById(id);
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
        public async Task<ActionResult<TypePrime>> Create([FromBody] TypePrime typePrime)
        {
            try
            {

                if
                (typePrime == null)
                {
                    return BadRequest();

                }
                else
                {
                    var org = await typePrimeRepository.GetByCriteria(typePrime.Libelle);
                    if (org == null)
                    {

                        var created = await typePrimeRepository.Add(typePrime);
                        return CreatedAtAction(nameof(GetById), new { id = created.TypePrimeId }, created);

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
        public async Task<ActionResult<TypePrime>> Update(int id, TypePrime objet)
        {

            try
            {

                if (id != objet.TypePrimeId)
                    return BadRequest("Type Prime ID mismatch");
                var organigrammeToUpdate = await typePrimeRepository.GetById(id);
                if (organigrammeToUpdate == null)
                    return NotFound($"type Prime with id ={id} not Found");
                return await typePrimeRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Type Prime data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TypePrime>> Delete(int id)
        {
            try
            {
                var objetToDelete = await typePrimeRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Type Prime with Id = {id} not found");
                }

                return await typePrimeRepository.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<TypePrime>>> Search(string name)
        {
            try
            {
                var result = await typePrimeRepository.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Type Prime data");
            }



        }



    }
}
