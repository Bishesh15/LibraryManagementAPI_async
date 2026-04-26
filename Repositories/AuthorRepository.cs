using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAsync()
            => await _context.Authors.ToListAsync();

        public async Task<Author> GetByIdAsync(int id)
            => await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);

        public async Task AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            if (data != null)
            {
                _context.Authors.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}