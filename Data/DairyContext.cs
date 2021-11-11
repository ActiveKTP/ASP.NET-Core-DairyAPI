using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class DairyContext : DbContext
    {
        public DairyContext(DbContextOptions<DairyContext> opt) : base(opt)
        {

        }

        public DbSet<Farm> Farm { get; set; }
        public DbSet<RefProvince> RefProvince { get; set; }
        public DbSet<RefAmphur> RefAmphur { get; set; }
        public DbSet<Cow> Cow { get; set; }
    }
}