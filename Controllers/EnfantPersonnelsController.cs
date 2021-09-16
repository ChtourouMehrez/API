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
    public class EnfantPersonnelsController : ControllerBase
    {
        private readonly IEnfantPersonnelRepository EnfantPersonnelRepository;
        //
        public EnfantPersonnelsController(IEnfantPersonnelRepository EnfantPersonnelRepository)
        {

            this.EnfantPersonnelRepository = EnfantPersonnelRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await EnfantPersonnelRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<EnfantPersonnel>> GetById(int id)
        {
            try
            {
                var result = await EnfantPersonnelRepository.GetById(id);
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
        public async Task<ActionResult<EnfantPersonnel>> Create([FromBody] EnfantPersonnel objet)
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
                    var obj = await EnfantPersonnelRepository.GetById(objet.EnfantPersonnelId);
                    if (obj == null)
                    {
                        //ISessionRepository sessionRepository = new SessionRepository();

                        var created = await EnfantPersonnelRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.EnfantPersonnelId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("ID", "Id Enfant Personnel il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating EnfantPersonnel");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<EnfantPersonnel>> Update(int id, EnfantPersonnel objet)
        {

            try
            {

                if (id != objet.EnfantPersonnelId)
                    return BadRequest("Enfant Personnel ID mismatch");
                var objetToUpdate = await EnfantPersonnelRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Enfant Personnel with id ={id} not Found");
                return await EnfantPersonnelRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Enfant Personnel data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EnfantPersonnel>> Delete(int id)
        {
            try
            {
                var objetToDelete = await EnfantPersonnelRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Enfant Personnel with Id = {id} not found");
                }

                return await EnfantPersonnelRepository.Delete(id);
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
        //        var result = await EnfantPersonnelRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving EnfantPersonnel data");
        //    }



        //}



    }
}
