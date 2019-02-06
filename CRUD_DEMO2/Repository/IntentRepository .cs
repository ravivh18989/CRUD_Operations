using CRUD_DEMO2;
using CRUD_DEMO2.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public class IntentRepository : IIntentRepository
    {
        public DBContext db;
        public IntentRepository(DBContext _db)
        {
            db = _db;
        }

        public async Task<Entity> GetIntent()
        {
            //try
            //{
            //    var intent = _db.Intent.ToList();
            //    return Ok(intent);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest();
            //}
            return  null;
        }


        public async Task<int> AddEntity(Intent intent)
        {
            if (db != null)
            {
                await db.Intent.AddAsync(intent);
                await db.SaveChangesAsync();

                return intent.Id;
            }

            return 0;
        }

        public async Task<int> DeleteIntent(int? id)
        {

            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var intent = await db.Intent.FirstOrDefaultAsync(e => e.Id == id);

                if (intent != null)
                {
                    //Delete that post
                    db.Intent.Remove(intent);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateIntent(Intent intent)
        {
            if (db != null)
            {
                //Delete that post
                db.Intent.Update(intent);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        Task<List<Entity>> IIntentRepository.GetIntent()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> AddIntent(Intent intent)
        {
            throw new System.NotImplementedException();
        }
    }
}