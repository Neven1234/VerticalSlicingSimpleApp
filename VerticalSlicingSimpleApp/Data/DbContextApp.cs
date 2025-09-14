

using Microsoft.EntityFrameworkCore;
using VerticalSlicingSimpleApp.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace VerticalSlicingSimpleApp.Data
{
    public class DbContextApp:DbContext
    {
      
        public DbContextApp(DbContextOptions<DbContextApp> options)
: base(options)
        {
        }
        public  DbSet<AuthorModel>authors { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
