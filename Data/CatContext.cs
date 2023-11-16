using Catopia.Models;
using Microsoft.EntityFrameworkCore;

namespace Catopia.Data
{
    public class CatContext : DbContext
    {
        public CatContext(DbContextOptions<CatContext> options) : base(options)
        {

        }

        public DbSet<Cat> Cats { get; set; }
    }
}
