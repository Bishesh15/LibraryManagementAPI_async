using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _authorService.GetAuthorsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _authorService.GetAuthorByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            await _authorService.AddAuthorAsync(author);
            return Ok("Author saved successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Author author)
        {
            await _authorService.UpdateAuthorAsync(author);
            return Ok("Author updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return Ok("Author deleted successfully");
        }
    }
}