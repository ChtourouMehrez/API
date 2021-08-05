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
    public class QualificationsController : ControllerBase
    {
        private readonly IQualificationRepository qualificationRepository;

        public QualificationsController(IQualificationRepository qualificationRepository)
        {

            this.qualificationRepository = qualificationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await qualificationRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Qualification>> GetById(int id)
        {
            try
            {
                var result = await qualificationRepository.GetById(id);
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
        public async Task<ActionResult<Qualification>> Create([FromBody] Qualification qualification)
        {
            try
            {

                if
                (qualification == null)
                {
                    return BadRequest();

                }
                else
                {
                    var org = await qualificationRepository.GetByCriteria(qualification.Libelle);
                    if (org == null)
                    {

                        var CreatedQualification = await qualificationRepository.Add(qualification);
                        return CreatedAtAction(nameof(GetById), new { id = CreatedQualification.Id }, CreatedQualification);

                    }
                    else
                    {
                        ModelState.AddModelError("Libelle", "Qualification Libelle already in use");
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
        public async Task<ActionResult<Qualification>> Update(int id, Qualification qualification)
        {

            try
            {

                if (id != qualification.Id)
                    return BadRequest("Qualification ID mismatch");
                var qualificationToUpdate = await qualificationRepository.GetById(id);
                if (qualificationToUpdate == null)
                    return NotFound($"qualification with id ={id} not Found");
                return await qualificationRepository.Update(qualification);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating qualification data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Qualification>> Delete(int id)
        {
            try
            {
                var qualificationToDelete = await qualificationRepository.GetById(id);

                if (qualificationToDelete == null)
                {
                    return NotFound($"Qualification with Id = {id} not found");
                }

                return await qualificationRepository.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Qualification>>> Search(string name)
        {
            try
            {
                var result = await qualificationRepository.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Qualifications data");
            }



        }



    }
}
