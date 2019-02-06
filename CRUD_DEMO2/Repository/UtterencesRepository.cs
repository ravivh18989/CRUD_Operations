using CRUD_DEMO2;
using CRUD_DEMO2.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public class UtterencesRepository : IUtterencesRepository
    {
        private DBContext db;
        public UtterencesRepository(DBContext _db)
        {
            db = _db;
        }

        public async Task<Entity> GetUtterences()
        {
            //try
            //{
            //    var utterences = _db.Utterences.ToList();
            //    return Ok(utterences);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest();
            //}
            return null;
        }


        public async Task<int> AddUtterences(Utterences utterences)
        {
            if (db != null)
            {
                await db.Utterences.AddAsync(utterences);
                await db.SaveChangesAsync();
                return utterences.Id;
            }

            return 0;
        }

        public async Task<int> DeleteUtterences(int? id)
        {

            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var utterences = await db.Utterences.FirstOrDefaultAsync(e => e.Id == id);

                if (utterences != null)
                {
                    //Delete that post
                    db.Utterences.Remove(utterences);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateUtterences(Utterences utterences)
        {
            if (db != null)
            {
                //Delete that post
                db.Utterences.Update(utterences);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        Task<List<Utterences>> IUtterencesRepository.GetUtterences()
        {
            throw new System.NotImplementedException();
        }
    }
}