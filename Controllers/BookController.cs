using api06.Models;
using api06.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _repository;

        public BookController(BookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Book> Get() => _repository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _repository.GetById(id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Post(Book book)
        {
            var addedBook = _repository.Add(book);
            return CreatedAtAction(nameof(Get), new { id = addedBook.Id }, addedBook);
        }
    }
}
