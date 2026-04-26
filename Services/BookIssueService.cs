using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using LibraryManagementAPI.Utilities;

namespace LibraryManagementAPI.Services
{
    public class BookIssueService : IBookIssueService
    {
        private readonly IBookIssueRepository _bookIssueRepository;
        private readonly ILogService _logService;

        public BookIssueService(IBookIssueRepository bookIssueRepository, ILogService logService)
        {
            _bookIssueRepository = bookIssueRepository;
            _logService = logService;
        }

        public async Task<List<BookIssue>> GetAllAsync()
        {
            try { return await _bookIssueRepository.GetAllAsync(); }
            catch (Exception ex) { _logService.SaveLog("Error fetching issues: " + ex.Message); throw; }
        }

        public async Task IssueBookAsync(BookIssue bookIssue)
        {
            try { await _bookIssueRepository.IssueBookAsync(bookIssue); }
            catch (Exception ex) { _logService.SaveLog("Error issuing book: " + ex.Message); throw; }
        }

        public async Task ReturnBookAsync(int issueId, DateTime returnDate)
        {
            try { await _bookIssueRepository.ReturnBookAsync(issueId, returnDate); }
            catch (Exception ex) { _logService.SaveLog("Error returning book: " + ex.Message); throw; }
        }
    }
}