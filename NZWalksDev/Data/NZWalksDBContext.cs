using Microsoft.EntityFrameworkCore;
using NZWalksDev.Models.Domain;

namespace NZWalksDev.Data
{
    public class NZWalksDBContext: DbContext
    {
        public NZWalksDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Region> Regions { get; set; }
    }
}
