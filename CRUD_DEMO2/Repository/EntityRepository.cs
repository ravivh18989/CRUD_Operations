using CoreServices.Repository;
using CRUD_DEMO2.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_DEMO2.Repository
{
    public class EntityRepository : IEntityRepository
    {
        private DBContext db;
        public EntityRepository(DBContext _db)
        {
            db = _db;
        }

        public async Task<Entity> GetEntity(int? Id)
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
            return await db.Entity.FirstOrDefaultAsync(e => e.Id == Id);
        }


        public async Task<int> AddEntity(Entity entity)
        {
            if (db != null)
            {
                await db.Entity.AddAsync(entity);
                await db.SaveChangesAsync();

                return entity.Id;
            }

            return 0;
        }

        public async Task<int> DeleteEntity(int? id)
        {

            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var entity = await db.Entity.FirstOrDefaultAsync(e => e.Id == id);

                if (entity != null)
                {
                    //Delete that post
                    db.Entity.Remove(entity);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateEntity(Entity entity)
        {
            if (db != null)
            {
                //Delete that post
                db.Entity.Update(entity);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        Task<List<Entity>> IEntityRepository.GetEntity(int? Id)
        {
            throw new System.NotImplementedException();
        }

    }
}