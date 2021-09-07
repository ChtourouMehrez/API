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
    public class BanquesController : ControllerBase
    {
        private readonly IBanqueRepository BanqueRepository;
        //
        public BanquesController(IBanqueRepository BanqueRepository)
        {

            this.BanqueRepository = BanqueRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await BanqueRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Banque>> GetById(int id)
        {
            try
            {
                var result = await BanqueRepository.GetById(id);
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
        public async Task<ActionResult<Banque>> Create([FromBody] Banque objet)
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
                    var obj = await BanqueRepository.GetById(objet.BanqueId);
                    if (obj == null)
                    {

                        var created = await BanqueRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.BanqueId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("ID", "Id Banque il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Banque");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Banque>> Update(int id, Banque objet)
        {

            try
            {

                if (id != objet.BanqueId)
                    return BadRequest("Banque ID mismatch");
                var objetToUpdate = await BanqueRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Banque with id ={id} not Found");
                return await BanqueRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Banque data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Banque>> Delete(int id)
        {
            try
            {
                var objetToDelete = await BanqueRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Banque with Id = {id} not found");
                }

                return await BanqueRepository.Delete(id);
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
        //        var result = await BanqueRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Banque data");
        //    }



        //}



    }
}
