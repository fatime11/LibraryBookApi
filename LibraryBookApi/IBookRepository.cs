using LibraryBookApi.Models;

namespace LibraryBookApi
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(int id, Book updatedBook);
        Task DeleteBookAsync(int id);
    }
}
