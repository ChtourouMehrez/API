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
    public class SessionsController : ControllerBase
    {
        private readonly ISessionRepository SessionRepository;

        public SessionsController(ISessionRepository SessionRepository)
        {

            this.SessionRepository = SessionRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await SessionRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Session>> GetById(int id)
        {
            try
            {
                var result = await SessionRepository.GetById(id);
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
        public async Task<ActionResult<Session>> Create([FromBody] Session objet)
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
                    var obj = await SessionRepository.GetById(objet.SessionKey);
                    if (obj == null)
                    {

                        var created = await SessionRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.SessionKey }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("ID", "Id Session il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Session");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Session>> Update(int id, Session objet)
        {

            try
            {

                if (id != objet.SessionKey)
                    return BadRequest("Session ID mismatch");
                var objetToUpdate = await SessionRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Session with id ={id} not Found");
                return await SessionRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Session data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Session>> Delete(int id)
        {
            try
            {
                var objetToDelete = await SessionRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Session with Id = {id} not found");
                }

                return await SessionRepository.Delete(id);
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
        //        var result = await SessionRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Session data");
        //    }



        //}



    }
}
