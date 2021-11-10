using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class FarmContext : DbContext
    {
        public FarmContext(DbContextOptions<FarmContext> opt) : base(opt)
        {

        }

        public DbSet<Farm> Farm { get; set; }
    }
}