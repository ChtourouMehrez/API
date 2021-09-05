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
    public class RegimesController : ControllerBase
    {
        private readonly IRegimeRepository RegimeRepository;

        public RegimesController(IRegimeRepository RegimeRepository)
        {

            this.RegimeRepository = RegimeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await RegimeRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Regime>> GetById(int id)
        {
            try
            {
                var result = await RegimeRepository.GetById(id);
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
        public async Task<ActionResult<Regime>> Create([FromBody] Regime objet)
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
                    var obj = await RegimeRepository.GetByCriteria(objet.Libelle);
                    if (obj == null)
                    {

                        var created = await RegimeRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.RegimeId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("Libelle", "Libelle Regime il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Regime");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Regime>> Update(int id, Regime objet)
        {

            try
            {

                if (id != objet.RegimeId)
                    return BadRequest("Regime ID mismatch");
                var objetToUpdate = await RegimeRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Regime with id ={id} not Found");
                return await RegimeRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Regime data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Regime>> Delete(int id)
        {
            try
            {
                var objetToDelete = await RegimeRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Regime with Id = {id} not found");
                }

                return await RegimeRepository.Delete(id);
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
        //        var result = await RegimeRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Regime data");
        //    }



        //}



    }
}
