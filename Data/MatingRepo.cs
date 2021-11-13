using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class MatingRepo : IMatingRepo
    {
        private readonly DairyContext _context;

        public MatingRepo(DairyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Mating>> GetAllMating()
        {
            var mating = (from m in _context.Mating
                          orderby m.date_updated descending
                          select m).Take(50).ToListAsync();
            return await mating;
        }

        public async Task<Mating> GetMatingByTranId(int maTranId)
        {
            var mating = _context.Mating.FindAsync(maTranId);
            return await mating;
        }
    }
}