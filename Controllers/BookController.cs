using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _bookService.GetBooksAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _bookService.GetBookByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _bookService.AddBookAsync(book);
            return Ok("Book saved successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Book book)
        {
            await _bookService.UpdateBookAsync(book);
            return Ok("Book updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok("Book deleted successfully");
        }
    }
}