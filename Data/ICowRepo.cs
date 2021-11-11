using System.Collections.Generic;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface ICowRepo
    {
        IEnumerable<Cow> GetAllCows();
        Cow GetCowById(string ccowId);

        IEnumerable<CowFarms> GetAllCowFarms();
        IEnumerable<CowFarms> GetAllCowFarms_Age4m();
        IEnumerable<CowFarms> GetAllCowFarms_Age12m();
        IEnumerable<CowFarms> GetAllCowFarms_Age18m();

        IEnumerable<CowFarms> GetAllCowFarms_Age4mByaiZone(string aiZone);
        IEnumerable<CowFarms> GetAllCowFarms_Age12mByaiZone(string aiZone);
        IEnumerable<CowFarms> GetAllCowFarms_Age18mByaiZone(string aiZone);
    }
}