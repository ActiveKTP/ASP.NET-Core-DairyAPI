using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface IGrowthRepo
    {
        Task<IEnumerable<Growth>> GetAllGrowth();
        Task<Growth> GetGrowthBygTranId(int gTranId);
    }
}