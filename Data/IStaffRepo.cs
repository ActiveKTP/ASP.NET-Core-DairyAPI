using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface IStaffRepo
    {
        Task<IEnumerable<Staff>> GetAllStaffs();
        Task<Staff> GetStaffById(string staffId);
    }
}