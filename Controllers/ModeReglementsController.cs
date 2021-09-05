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
    public class ModeReglementsController : ControllerBase
    {
        private readonly IModeReglementRepository ModeReglementRepository;

        public ModeReglementsController(IModeReglementRepository ModeReglementRepository)
        {

            this.ModeReglementRepository = ModeReglementRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await ModeReglementRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModeReglement>> GetById(int id)
        {
            try
            {
                var result = await ModeReglementRepository.GetById(id);
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
        public async Task<ActionResult<ModeReglement>> Create([FromBody] ModeReglement objet)
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
                    var obj = await ModeReglementRepository.GetByCriteria(objet.Libelle);
                    if (obj == null)
                    {

                        var created = await ModeReglementRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.ModeReglementId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("Libelle", "Libelle Mode Paiement il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Mode Paiemet");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<ModeReglement>> Update(int id, ModeReglement objet)
        {

            try
            {

                if (id != objet.ModeReglementId)
                    return BadRequest("Mode Paiement ID mismatch");
                var objetToUpdate = await ModeReglementRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Mode Paiement with id ={id} not Found");
                return await ModeReglementRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Mode Paiement data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ModeReglement>> Delete(int id)
        {
            try
            {
                var objetToDelete = await ModeReglementRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Mode Paiement with Id = {id} not found");
                }

                return await ModeReglementRepository.Delete(id);
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
        //        var result = await ModeReglementRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving ModeReglement data");
        //    }



        //}



    }
}
