using System.Collections.Generic;
using System.Linq;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public class FarmRepo : IFarmRepo
    {
        private readonly FarmContext _context;

        public FarmRepo(FarmContext context)
        {
            _context = context;
        }

        public IEnumerable<Farm> GetAllFarms()
        {
            var farms = (from farm in _context.Farm
                         where (farm.fStatus == "01")
                         orderby farm.fFarmId
                         select farm).Take(50);
            return farms;
        }

        public Farm GetFarmById(string fFarmId)
        {
            var farm = _context.Farm.FirstOrDefault(i => i.fFarmId == fFarmId);
            return farm;
        }

    }
}