

using Microsoft.EntityFrameworkCore;
using VerticalSlicingSimpleApp.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace VerticalSlicingSimpleApp.Data
{
    public class DbContextAdd:DbContext
    {
      
        public DbContextAdd(DbContextOptions<DbContextAdd> options)
: base(options)
        {
        }
        public  DbSet<AuthorModel>authors { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
