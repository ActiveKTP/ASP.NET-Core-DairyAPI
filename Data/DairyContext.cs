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
        public DbSet<CowBreed> CowBreed { get; set; }
        public DbSet<CowFarmData> CowFarmData { get; set; }
        public DbSet<Mating> Mating { get; set; }
        public DbSet<Calving> Calving { get; set; }
        public DbSet<Calve> Calve { get; set; }
        public DbSet<Growth> Growth { get; set; }

        public DbSet<CowFarms> CowFarms { get; set; }
        public DbSet<CowFarmsMatingPG> CowFarmsMatingPG { get; set; }
        public DbSet<CowFarmsGrowth> CowFarmsGrowth { get; set; }
        public DbSet<CowFarmsGrowthCV> CowFarmsGrowthCV { get; set; }

    }
}