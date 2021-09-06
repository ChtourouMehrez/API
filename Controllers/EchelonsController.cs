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
    public class EchelonsController : ControllerBase
    {
        private readonly IEchelonRepository EchelonRepository;

        public EchelonsController(IEchelonRepository EchelonRepository)
        {

            this.EchelonRepository = EchelonRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await EchelonRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Echelon>> GetById(int id)
        {
            try
            {
                var result = await EchelonRepository.GetById(id);
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
        public async Task<ActionResult<Echelon>> Create([FromBody] Echelon objet)
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
                    var obj = await EchelonRepository.GetByCriteria(objet.Libelle);
                    if (obj == null)
                    {

                        var created = await EchelonRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.EchelonId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("Libelle", "Libelle Echelon il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Echelon");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Echelon>> Update(int id, Echelon objet)
        {

            try
            {

                if (id != objet.EchelonId)
                    return BadRequest("Echelon ID mismatch");
                var objetToUpdate = await EchelonRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Echelon with id ={id} not Found");
                return await EchelonRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Echelon data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Echelon>> Delete(int id)
        {
            try
            {
                var objetToDelete = await EchelonRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Echelon with Id = {id} not found");
                }

                return await EchelonRepository.Delete(id);
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
        //        var result = await EchelonRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Echelon data");
        //    }



        //}



    }
}
