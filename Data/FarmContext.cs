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
        public DbSet<RefProvince> RefProvince { get; set; }
        public DbSet<RefAmphur> RefAmphur { get; set; }
    }
}