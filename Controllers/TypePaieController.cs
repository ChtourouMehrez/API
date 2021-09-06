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
    public class TypePaieController : ControllerBase
    {
        private readonly ITypePaiesRepository typePaieRepository;

        public TypePaieController(ITypePaiesRepository typePaieRepository)
        {

            this.typePaieRepository = typePaieRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await typePaieRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<TypePaies>> GetById(int id)
        {
            try
            {
                var result = await typePaieRepository.GetById(id);
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
        public async Task<ActionResult<TypePaies>> Create([FromBody] TypePaies objet)
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
                    var obj = await typePaieRepository.GetByCriteria(objet.CodePaie);
                    if (obj == null)
                    {

                        var created = await typePaieRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.TypePaiesId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("Code", "Code Paie il already in use");
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
        public async Task<ActionResult<TypePaies>> Update(int id, TypePaies objet)
        {

            try
            {

                if (id != objet.TypePaiesId)
                    return BadRequest("Type Prime ID mismatch");
                var objetToUpdate = await typePaieRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"type Prime with id ={id} not Found");
                return await typePaieRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Type Prime data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TypePaies>> Delete(int id)
        {
            try
            {
                var objetToDelete = await typePaieRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Type Paie with Id = {id} not found");
                }

                return await typePaieRepository.Delete(id);
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
        //        var result = await typePaieRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Type Prime data");
        //    }



        //}



    }
}
