using CoreServices.Repository;
using CRUD_DEMO2.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace CRUD_DEMO2.Controllers
{
    [Produces("application/json")]
    [Route("api/Utterences")]
    public class UtterencesController : Controller
    {

        IUtterencesRepository utterencesRepository;
        public UtterencesController(IUtterencesRepository _utterencesRepository)
        {
            utterencesRepository = _utterencesRepository;
        }
        private DBContext _db;

        public UtterencesController(DBContext context)
        {
            _db = context;
        }




        private bool UtterencesExists(int id)
        {
            return _db.Utterences.Any(e => e.Id == id);
        }

        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var entity = await utterencesRepository.GetUtterences();
                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(Utterences utterences)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await utterencesRepository.AddUtterences(utterences);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = 0;

            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await utterencesRepository.DeleteUtterences(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] Utterences utterences)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await utterencesRepository.UpdateUtterences(utterences);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}