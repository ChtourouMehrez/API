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
    public class UtilisateursController : ControllerBase
    {
        private readonly IUtilisateurRepository UtilisateurRepository;
        //
        public UtilisateursController(IUtilisateurRepository UtilisateurRepository)
        {

            this.UtilisateurRepository = UtilisateurRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await UtilisateurRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Utilisateur>> GetById(int id)
        {
            try
            {
                var result = await UtilisateurRepository.GetById(id);
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
        public async Task<ActionResult<Utilisateur>> Create([FromBody] Utilisateur objet)
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
                    var obj = await UtilisateurRepository.GetById(objet.UtilisateurId);
                    if (obj == null)
                    {

                        var created = await UtilisateurRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.UtilisateurId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("ID", "Id Utilisateur il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Utilisateur");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Utilisateur>> Update(int id, Utilisateur objet)
        {

            try
            {

                if (id != objet.UtilisateurId)
                    return BadRequest("Utilisateur ID mismatch");
                var objetToUpdate = await UtilisateurRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Utilisateur with id ={id} not Found");
                return await UtilisateurRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Utilisateur data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Utilisateur>> Delete(int id)
        {
            try
            {
                var objetToDelete = await UtilisateurRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Utilisateur with Id = {id} not found");
                }

                return await UtilisateurRepository.Delete(id);
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
        //        var result = await UtilisateurRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Utilisateur data");
        //    }



        //}



    }
}
