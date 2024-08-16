using BookApp.WebAPI;
using BookApp.WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//5. Add GET method that returns all books

//6.Add GET method that returns one book by sending index in the query string

//7. Add GET method that returns one book by filtering by author and title (use query string parameters)

//8. Add POST method that adds new book to the list of books (use the FromBody attribute) 


namespace BookApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("queryString")]
        public ActionResult<Book> GetByQueryString([FromQuery] int? index)
        {
            try
            {
                if (index == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Index is a requred parameter");
                }
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The index can not be negative!");

                }
                if (index >= StaticDb.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no resource on index {index}");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books[(index-1).Value]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet("filter")]
        public ActionResult<List<Book>> FilterByAuthorAndTitle([FromQuery] string? author, [FromQuery] string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return Ok(StaticDb.Books);
                }
                if (string.IsNullOrEmpty(author))
                {
                    List<Book> filteredByTitle = StaticDb.Books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
                    return Ok(filteredByTitle);
                }
                if (string.IsNullOrEmpty(title))
                {
                    List<Book> filteredByAuthor = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
                    return Ok(filteredByAuthor);
                }
                List<Book> booksDb = StaticDb.Books
                .Where(x => x.Title.ToLower().Contains(title.ToLower())
                 && x.Author.ToLower().Contains(author.ToLower()))
                .ToList();
                return Ok(booksDb);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("The book must have an author and a title");
                }
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book was created.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        //## Bonus

        //Add POST method that accepts list of  books from the body of the request and returns their titles as a list of strings.
        [HttpPost("bookTitle")]
        public IActionResult GetBookTitles([FromBody] List<Book> books)
        {
            try
            {
                if (books is not null && books.Count > 0)
                {
                    var titles = books.Select(b => b.Title).ToList();
                    return Ok(titles);
                }
                return BadRequest("The list of books is empty!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}
