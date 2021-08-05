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
    public class TypePaiesController : ControllerBase
    {
        private readonly ITypePaieRepository typePaieRepository;

        public TypePaiesController(ITypePaieRepository typePaieRepository)
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
        public async Task<ActionResult<TypePaie>> GetById(int id)
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

        //[HttpPost]
        //public async Task<ActionResult<TypePaie>> Create([FromBody] TypePaie typePrime)
        //{
        //    try
        //    {

        //        if
        //        (typePrime == null)
        //        {
        //            return BadRequest();

        //        }
        //        else
        //        {
        //            var org = await typePaieRepository.GetByCriteria(typePrime.codePaie);
        //            if (org == null)
        //            {

        //                var created = await typePrimeRepository.Add(typePrime);
        //                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

        //            }
        //            else
        //            {
        //                ModelState.AddModelError("Libelle", "Libelle il already in use");
        //                return BadRequest(ModelState);
        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Type Prime");
        //    }
        //}


        [HttpPut("{id:int}")]
        public async Task<ActionResult<TypePaie>> Update(int id, TypePaie objet)
        {

            try
            {

                if (id != objet.Id)
                    return BadRequest("Type Prime ID mismatch");
                var organigrammeToUpdate = await typePaieRepository.GetById(id);
                if (organigrammeToUpdate == null)
                    return NotFound($"type Prime with id ={id} not Found");
                return await typePaieRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Type Prime data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TypePaie>> Delete(int id)
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
