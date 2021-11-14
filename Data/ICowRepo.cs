using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface ICowRepo
    {
        Task<IEnumerable<Cow>> GetAllCows();
        Task<Cow> GetCowById(string ccowId);

        Task<IEnumerable<CowFarms>> GetAllCowFarms();
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age4m();//30 Days
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age12m();//30 Days
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18m();//30 Days

        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age4mByaiZone(string aiZone);//30 Days
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age12mByaiZone(string aiZone);//30 Days
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18mByaiZone(string aiZone);//30 Days
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age4mByaiZone_setDate(string aiZone, DateTime startDate, DateTime endDate);
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age12mByaiZone_setDate(string aiZone, DateTime startDate, DateTime endDate);
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age18mByaiZone_setDate(string aiZone, DateTime startDate, DateTime endDate);
        Task<IEnumerable<CowFarms>> GetAllCowFarms_Age(int age, string aiZone, DateTime startDate, DateTime endDate);

        Task<IEnumerable<CowFarmsMatingPG>> GetAllCowFarmsMatingPG();
        Task<IEnumerable<CowFarmsMatingPG>> GetAllCowFarmsMatingPGByaiZone(string aiZone);


    }
}