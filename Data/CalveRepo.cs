using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class CalveRepo : ICalveRepo
    {
        private readonly DairyContext _context;

        public CalveRepo(DairyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Calve>> GetAllCalve()
        {
            var calve = (from c in _context.Calve
                         orderby c.date_updated descending
                         select c).Take(50).ToListAsync();
            return await calve;
        }

        public async Task<Calve> GetCalveBycvgTranId(int cvgTranId)
        {
            var calve = _context.Calve.FindAsync(cvgTranId);
            return await calve;
        }
    }
}