using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services
{
    public interface IBookIssueService
    {
        Task<List<BookIssue>> GetAllAsync();
        Task IssueBookAsync(BookIssue bookIssue);
        Task ReturnBookAsync(int issueId, DateTime returnDate);
    }
}