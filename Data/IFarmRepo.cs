using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface IFarmRepo
    {
        Task<IEnumerable<Farm>> GetAllFarms();
        Task<Farm> GetFarmById(string fFarmId);

        //List<string> GetAllFarmsData();
    }
}