using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpDelete(Name = "DeleteBook")]
        public void DeleteBook(Guid id)
        {
            //var result = dbContext.Books.FirstOrDefault(x => x.Id == id);
            var result = dbContext.Books.Find(id);

            if (result!=null)
            {
                dbContext.Books.Remove(result);
                dbContext.SaveChanges();
            }
        }

        [HttpPut(Name = "UpdateBook")]
        public void UpdateBook(Book book,Guid id)
        {
            var result = dbContext.Books.Find(id);
            if (result != null)
            {
                result.Author = book.Author;
                result.ISBN = book.ISBN;
                result.Title = book.Title;
                dbContext.Books.Update(result);
                dbContext.SaveChanges();
            }
        }
    }
}
