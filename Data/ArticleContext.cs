using Catopia.Models;
using Microsoft.EntityFrameworkCore;

namespace Catopia.Data
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options) 
        { 

        }

        public DbSet<Article> Articles { get; set;}
    }
}
