using System.Collections.Generic;
using System.Linq;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public class CowRepo : ICowRepo
    {
        private readonly DairyContext _context;

        public CowRepo(DairyContext context)
        {
            _context = context;
        }
        public IEnumerable<Cow> GetAllCows()
        {
            var cows = (from cow in _context.Cow
                        where (cow.cMilkingStatus.Contains("MK") && cow.cActiveFlag == 1)
                        orderby cow.ccowId
                        select cow).Take(50);
            return cows;
        }

        public Cow GetCowById(string ccowId)
        {
            var cow = _context.Cow.FirstOrDefault(i => i.ccowId == ccowId);
            return cow;
        }
    }
}