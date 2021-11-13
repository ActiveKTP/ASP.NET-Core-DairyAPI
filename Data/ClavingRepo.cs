using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class CalvingRepo : ICalvingRepo
    {
        private readonly DairyContext _context;

        public CalvingRepo(DairyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Calving>> GetAllCalving()
        {
            var calving = (from c in _context.Calving
                           orderby c.date_updated descending
                           select c).Take(50).ToListAsync();
            return await calving;
        }

        public async Task<Calving> GetCalvingBycvgTranId(int cvgTranId)
        {
            var calving = _context.Calving.FindAsync(cvgTranId);
            return await calving;
        }
    }
}