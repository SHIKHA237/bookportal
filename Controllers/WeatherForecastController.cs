using Microsoft.AspNetCore.Mvc;
using BookAPI.Models;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
       

        private static List<Book> books = new List<Book>();


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        //[Route("Default/WeatherForecast")]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> WeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }



        //[HttpGet(Name = "GetBook")]
        //public List<Book> Book()
        //{
        //    return books;
        //}

        [HttpGet("{id}/{title}")]
        public Book BookByID(string id, string title)
        {
             foreach(var book in books)
            {
                if(book.ISBN == id && book.Title == title)
                {
                    return book;
                }
            }
            return null;
        }

        //[HttpPost(Name = "CreateBook")]
        //public void CreateBook(Book book)
        //{
        //    books.Add(book);
        //}
    }     
}