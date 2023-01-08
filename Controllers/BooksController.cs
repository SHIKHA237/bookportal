using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class BooksController : Controller
    {
        private readonly BookApiDbContext dbContext;

        public BooksController(BookApiDbContext dbContext)
        {             
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            return dbContext.Books.ToList();
        }


        [HttpPost(Name = "CreateBook")]
        public void CreateBook(Book book)
        {
            book.Id = Guid.NewGuid();
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }
    }
}
