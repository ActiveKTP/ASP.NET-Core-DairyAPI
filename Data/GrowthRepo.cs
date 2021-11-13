using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class GrowthRepo : IGrowthRepo
    {
        private readonly DairyContext _context;

        public GrowthRepo(DairyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Growth>> GetAllGrowth()
        {
            var growth = (from m in _context.Growth
                          orderby m.date_updated descending
                          select m).Take(50).ToListAsync();
            return await growth;
        }

        public async Task<Growth> GetGrowthBygTranId(int gTranId)
        {
            var growth = _context.Growth.FindAsync(gTranId);
            return await growth;
        }
    }
}