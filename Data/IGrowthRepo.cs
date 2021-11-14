using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface IGrowthRepo
    {
        Task<IEnumerable<Growth>> GetAllGrowth();
        Task<Growth> GetGrowthBygTranId(int gTranId);

        Task<IEnumerable<CowFarmsGrowth>> GetAllCowFarmsGrowth_type_aiZone(string type, string aiZone, int year, int month);
        Task<IEnumerable<CowFarmsGrowthCV>> GetAllCowFarmsGrowthCV_aiZone(string aiZone, int year, int month);
    }
}