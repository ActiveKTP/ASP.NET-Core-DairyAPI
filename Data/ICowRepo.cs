using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface ICowRepo
    {
        Task<IEnumerable<Cow>> GetAllCows();
        Task<Cow> GetCowById(string ccowId);

        Task<IEnumerable<CowFarms>> GetAllCowFarms();
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age4m();
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age12m();
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18m();

        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age4mByaiZone(string aiZone);
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age12mByaiZone(string aiZone);
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18mByaiZone(string aiZone);
    }
}