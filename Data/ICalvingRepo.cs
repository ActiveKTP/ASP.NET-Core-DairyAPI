using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface ICalvingRepo
    {
        Task<IEnumerable<Calving>> GetAllCalving();
        Task<Calving> GetCalvingBycvgTranId(int cvgTranId);
    }
}