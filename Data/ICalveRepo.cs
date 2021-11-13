using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface ICalveRepo
    {
        Task<IEnumerable<Calve>> GetAllCalve();
        Task<Calve> GetCalveBycvgTranId(int cvgTranId);
    }
}