using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Repositories
{
    public class BookIssueRepository : IBookIssueRepository
    {
        private readonly LibraryDbContext _context;

        public BookIssueRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookIssue>> GetAllAsync()
            => await _context.BookIssues.ToListAsync();

        public async Task IssueBookAsync(BookIssue bookIssue)
        {
            _context.BookIssues.Add(bookIssue);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnBookAsync(int issueId, DateTime returnDate)
        {
            var data = await _context.BookIssues.FirstOrDefaultAsync(x => x.IssueId == issueId);
            if (data != null)
            {
                data.ReturnDate = returnDate;
                data.Status = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}