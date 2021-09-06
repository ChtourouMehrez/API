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
    public class NaturesController : ControllerBase
    {
        private readonly INatureRepository NatureRepository;

        public NaturesController(INatureRepository NatureRepository)
        {

            this.NatureRepository = NatureRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await NatureRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Nature>> GetById(int id)
        {
            try
            {
                var result = await NatureRepository.GetById(id);
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
        public async Task<ActionResult<Nature>> Create([FromBody] Nature objet)
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
                    var obj = await NatureRepository.GetByCriteria(objet.Libelle);
                    if (obj == null)
                    {

                        var created = await NatureRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.NatureId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("Libelle", "Libelle Nature il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Nature");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Nature>> Update(int id, Nature objet)
        {

            try
            {

                if (id != objet.NatureId)
                    return BadRequest("Nature ID mismatch");
                var objetToUpdate = await NatureRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Nature with id ={id} not Found");
                return await NatureRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Nature data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Nature>> Delete(int id)
        {
            try
            {
                var objetToDelete = await NatureRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Nature with Id = {id} not found");
                }

                return await NatureRepository.Delete(id);
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
        //        var result = await NatureRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Nature data");
        //    }



        //}



    }
}
