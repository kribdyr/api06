using api06.Models;

namespace api06.Repo
{
    public class BookRepository
    {
        private readonly List<Book> _books = new();

        public IEnumerable<Book> GetAll() => _books;

        public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public Book Add(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return book;
        }
    }
}
