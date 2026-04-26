using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using LibraryManagementAPI.Utilities;

namespace LibraryManagementAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogService _logService;

        public AuthorService(IAuthorRepository authorRepository, ILogService logService)
        {
            _authorRepository = authorRepository;
            _logService = logService;
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            try { return await _authorRepository.GetAllAsync(); }
            catch (Exception ex) { _logService.SaveLog("Error fetching authors: " + ex.Message); throw; }
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            try { return await _authorRepository.GetByIdAsync(id); }
            catch (Exception ex) { _logService.SaveLog("Error fetching author: " + ex.Message); throw; }
        }

        public async Task AddAuthorAsync(Author author)
        {
            try { await _authorRepository.AddAsync(author); }
            catch (Exception ex) { _logService.SaveLog("Error adding author: " + ex.Message); throw; }
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            try { await _authorRepository.UpdateAsync(author); }
            catch (Exception ex) { _logService.SaveLog("Error updating author: " + ex.Message); throw; }
        }

        public async Task DeleteAuthorAsync(int id)
        {
            try { await _authorRepository.DeleteAsync(id); }
            catch (Exception ex) { _logService.SaveLog("Error deleting author: " + ex.Message); throw; }
        }
    }
}