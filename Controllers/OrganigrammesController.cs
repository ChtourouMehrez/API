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
    public class OrganigrammesController : ControllerBase
    {
        private readonly IOrganigrammeRepository organigrammeRepository;
         
        public OrganigrammesController(IOrganigrammeRepository organigrammeRepository)
        {
           
            this.organigrammeRepository = organigrammeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrganigrammes()
        {
            try
            {
                return Ok(await organigrammeRepository.GetOrganigrammes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Organigramme>> GetOrganigramme(int id)
        {
            try
            {
                var result = await organigrammeRepository.GetOrganigramme(id);
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
        public async Task<ActionResult<Employee>> CreateOrganigramme([FromBody] Organigramme organigramme)
        {
            try
            {

                if
                (organigramme == null)
                {
                    return BadRequest();

                }
                else
                {
                    var org = await organigrammeRepository.GetOrganigrammeByLibelle(organigramme.Libelle);
                    if (org == null)
                    {
                       
                        var CreatedOrganigramme = await organigrammeRepository.AddOrganigramme(organigramme);
                        return CreatedAtAction(nameof(GetOrganigramme), new { id = CreatedOrganigramme.Id }, CreatedOrganigramme);

                    }
                    else
                    {
                        ModelState.AddModelError("Libelle", "Organigramme email already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Employee");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Organigramme>> UpdateOrganigramme(int id, Organigramme organigramme)
        {

            try
            {

                if (id != organigramme.Id)
                    return BadRequest("Employee ID mismatch");
                var organigrammeToUpdate = await organigrammeRepository.GetOrganigramme(id);
                if (organigrammeToUpdate == null)
                    return NotFound($"Organigramme with id ={id} not Found");
                return await organigrammeRepository.UpdateOrganigramme(organigramme);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating organigramme data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Organigramme>> DeleteOrganigramme(int id)
        {
            try
            {
                var organigrammeToDelete = await organigrammeRepository.GetOrganigramme(id);

                if (organigrammeToDelete == null)
                {
                    return NotFound($"Organigramme with Id = {id} not found");
                }

                return await organigrammeRepository.DeleteOrganigramme(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Organigramme>>> Search(string name)
        {
            try
            {
                var result = await organigrammeRepository.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Organigrammes data");
            }



        }
      

        
    }
}
