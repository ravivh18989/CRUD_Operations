using CRUD_DEMO2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public interface IIntentRepository
    {
        Task<List<Entity>> GetIntent();

        Task<int> AddIntent(Intent intent);

        Task<int> DeleteIntent(int? Id);

        Task UpdateIntent(Intent Intent);
    }
}