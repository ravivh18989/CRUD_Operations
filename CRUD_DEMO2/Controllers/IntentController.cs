using CoreServices.Repository;
using CRUD_DEMO2.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_DEMO2.Controllers
{
    [Produces("application/json")]
    [Route("api/Intent")]
    public class IntentController : Controller
    {

        IIntentRepository intentRepository;
        public IntentController(IIntentRepository _intentRepository)
        {
            intentRepository = _intentRepository;
        }
        //private DBContext _db;

        //public IntentController(DBContext context)
        //{
        //    _db = context;
        //}




        //private bool IntentExists(int id)
        //{
        //    return _db.Entity.Any(e => e.Id == id);
        //}

        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var entity = await intentRepository.GetIntent();
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
        public async Task<IActionResult> Create(Intent intent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await intentRepository.AddIntent(intent);
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
                result = await intentRepository.DeleteIntent(id);
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
        public async Task<IActionResult> Edit([FromBody] Intent intent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await intentRepository.UpdateIntent(intent);

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