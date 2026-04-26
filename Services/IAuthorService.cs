using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
    }
}