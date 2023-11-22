using LibraryBookApi.Models;
using System.Data.Entity;

namespace LibraryBookApi
{
    public class BookRepository:IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context ;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(int id, Book updatedBook)
        {
            if (updatedBook == null)
            {
                throw new ArgumentNullException(nameof(updatedBook));
            }

            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                book.Title = updatedBook.Title;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
