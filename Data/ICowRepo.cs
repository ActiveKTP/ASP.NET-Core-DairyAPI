using System.Collections.Generic;
using DairyAPI.Models;

namespace DairyAPI.Data
{
    public interface ICowRepo
    {
        IEnumerable<Cow> GetAllCows();
        Cow GetCowById(string ccowId);
    }
}