using DairyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyAPI.Data
{
    public class CowContext : DbContext
    {
        public CowContext(DbContextOptions<CowContext> opt) : base(opt)
        {

        }

        public DbSet<Cow> Cow { get; set; }
    }
}