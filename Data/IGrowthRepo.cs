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

        Task<CowFarmsGrowth> GetGrowthByCowId_gStatus(string ccowId, string type);
        Task<CowFarmsGrowthCV> GetGrowth_CVByCowId_gStatus(string ccowId, string type);
        Task<IEnumerable<CowFarmsGrowth>> GetAllCowFarmsGrowth_type_aiZone(string type, string aiZone, int year, int month, int _start, int _limit);
        Task<IEnumerable<CowFarmsGrowthCV>> GetAllCowFarmsGrowthCV_aiZone(string aiZone, int year, int month, int _start, int _limit);
    }
}