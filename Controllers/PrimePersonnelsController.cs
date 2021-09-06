using API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Threading.Tasks;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimePersonnelsController : ControllerBase
    {
        private readonly IPrimePersonnelRepository PrimePersonnelRepository;

        public PrimePersonnelsController(IPrimePersonnelRepository PrimePersonnelRepository)
        {

            this.PrimePersonnelRepository = PrimePersonnelRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await PrimePersonnelRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<PrimePersonnel>> GetById(int id)
        {
            try
            {
                var result = await PrimePersonnelRepository.GetById(id);
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
        public async Task<ActionResult<PrimePersonnel>> Create([FromBody] PrimePersonnel objet)
        {
            try
            {

                if
                (objet == null)
                {
                    return BadRequest();

                }
                else
                {
                    var obj = await PrimePersonnelRepository.GetById(objet.PrimePersonnelId);
                    if (obj == null)
                    {

                        var created = await PrimePersonnelRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.PrimePersonnelId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("ID", "Id PrimePersonnel il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating PrimePersonnel");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<PrimePersonnel>> Update(int id, PrimePersonnel objet)
        {

            try
            {

                if (id != objet.PrimePersonnelId)
                    return BadRequest("PrimePersonnel ID mismatch");
                var objetToUpdate = await PrimePersonnelRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"PrimePersonnel with id ={id} not Found");
                return await PrimePersonnelRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating PrimePersonnel data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PrimePersonnel>> Delete(int id)
        {
            try
            {
                var objetToDelete = await PrimePersonnelRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"PrimePersonnel with Id = {id} not found");
                }

                return await PrimePersonnelRepository.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        //[HttpGet("{search}")]
        //public async Task<ActionResult<IEnumerable<TypePrime>>> Search(string name)
        //{
        //    try
        //    {
        //        var result = await PrimePersonnelRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving PrimePersonnel data");
        //    }



        //}



    }
}
