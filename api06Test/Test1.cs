using api06.Models;
using api06.Repo;


namespace api06Test

{
    [TestClass]
    public class BookRepositoryTests
    {
        [TestMethod]
        public void AddBook_ShouldAssignId()
        {
            // Arrange
            var repo = new BookRepository();
            var book = new Book { Title = "Test Book", Author = "Author A" };

            // Act
            var result = repo.Add(book);

            // Assert
            Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual("Test Book", result.Title);
        }
    }
}
