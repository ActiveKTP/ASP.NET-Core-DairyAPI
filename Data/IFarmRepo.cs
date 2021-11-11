using System.Collections.Generic;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface IFarmRepo
    {
        IEnumerable<Farm> GetAllFarms();
        Farm GetFarmById(string fFarmId);

        //List<string> GetAllFarmsData();
    }
}