using CRUD_DEMO2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public interface IUtterencesRepository
    {
        Task<List<Utterences>> GetUtterences();

        Task<int> AddUtterences(Utterences utterences);

        Task<int> DeleteUtterences(int? Id);

        Task UpdateUtterences(Utterences utterences);
    }
}