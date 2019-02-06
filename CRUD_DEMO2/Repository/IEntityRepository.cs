using CRUD_DEMO2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public interface IEntityRepository
    {
        Task<List<Entity>> GetEntity(int? Id);

        Task<int> AddEntity(Entity entity);

        Task<int> DeleteEntity(int? Id);

        Task UpdateEntity(Entity entity);
    }
}