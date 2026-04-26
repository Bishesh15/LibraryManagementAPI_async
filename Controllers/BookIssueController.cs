using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookIssueController : ControllerBase
    {
        private readonly IBookIssueService _bookIssueService;

        public BookIssueController(IBookIssueService bookIssueService)
        {
            _bookIssueService = bookIssueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _bookIssueService.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> IssueBook(BookIssue bookIssue)
        {
            await _bookIssueService.IssueBookAsync(bookIssue);
            return Ok("Book issued successfully");
        }

        [HttpPut("return/{issueId}")]
        public async Task<IActionResult> ReturnBook(int issueId)
        {
            await _bookIssueService.ReturnBookAsync(issueId, DateTime.Now);
            return Ok("Book returned successfully");
        }
    }
}