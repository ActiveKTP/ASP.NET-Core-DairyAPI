using System.Collections.Generic;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public class FarmRepo : IFarmRepo
    {
        public IEnumerable<Farm> GetAllFarms()
        {
            throw new System.NotImplementedException();
        }

        public Farm GetFarmById(int ccowNo)
        {
            throw new System.NotImplementedException();
        }
    }
}