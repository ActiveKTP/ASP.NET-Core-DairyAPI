using System.Collections.Generic;
using System.Threading.Tasks;

namespace DairyAPI.Data
{
    public interface IMatingRepo
    {
        Task<IEnumerable<Mating>> GetAllMating();
        Task<Mating> GetMatingByTranId(int maTranId);
    }
}