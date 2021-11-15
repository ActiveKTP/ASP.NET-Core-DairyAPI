using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface IGrowthRepo
    {
        //bool SaveChanges();

        Task<Growth> CreateGrowth(Growth growth);
        Task<IEnumerable<Growth>> GetAllGrowth();
        Task<Growth> GetGrowthBygTranId(int gTranId);
        Task Update(Growth growth);
        Task Delete(Growth growth);

        Task<IEnumerable<CowFarmsGrowth>> GetAllCowFarmsGrowth_type_aiZone(string type, string aiZone, int year, int month);
        Task<IEnumerable<CowFarmsGrowthCV>> GetAllCowFarmsGrowthCV_aiZone(string aiZone, int year, int month);
    }
}