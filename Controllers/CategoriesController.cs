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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieRepository CategorieRepository;

        public CategoriesController(ICategorieRepository CategorieRepository)
        {

            this.CategorieRepository = CategorieRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await CategorieRepository.GetALL());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categorie>> GetById(int id)
        {
            try
            {
                var result = await CategorieRepository.GetById(id);
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
        public async Task<ActionResult<Categorie>> Create([FromBody] Categorie objet)
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
                    var obj = await CategorieRepository.GetByCriteria(objet.Libelle);
                    if (obj == null)
                    {

                        var created = await CategorieRepository.Add(objet);
                        return CreatedAtAction(nameof(GetById), new { id = created.CategorieId }, created);

                    }
                    else
                    {
                        ModelState.AddModelError("Libelle", "Libelle Categorie il already in use");
                        return BadRequest(ModelState);
                    }

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Categorie");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Categorie>> Update(int id, Categorie objet)
        {

            try
            {

                if (id != objet.CategorieId)
                    return BadRequest("Categorie ID mismatch");
                var objetToUpdate = await CategorieRepository.GetById(id);
                if (objetToUpdate == null)
                    return NotFound($"Categorie with id ={id} not Found");
                return await CategorieRepository.Update(objet);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Categorie data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Categorie>> Delete(int id)
        {
            try
            {
                var objetToDelete = await CategorieRepository.GetById(id);

                if (objetToDelete == null)
                {
                    return NotFound($"Categorie with Id = {id} not found");
                }

                return await CategorieRepository.Delete(id);
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
        //        var result = await CategorieRepository.Search(name);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error Receiving Categorie data");
        //    }



        //}



    }
}
