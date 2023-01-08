using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class BookApiDbContext : DbContext
    {
        public BookApiDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
            

    }
}
