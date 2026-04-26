using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repositories
{
    public interface IBookIssueRepository
    {
        Task<List<BookIssue>> GetAllAsync();
        Task IssueBookAsync(BookIssue bookIssue);
        Task ReturnBookAsync(int issueId, DateTime returnDate);
    }
}