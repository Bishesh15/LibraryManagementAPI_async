using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
            => await _context.Books.ToListAsync();

        public async Task<Book> GetByIdAsync(int id)
            => await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

        public async Task AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (data != null)
            {
                _context.Books.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}