using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using LibraryManagementAPI.Utilities;

namespace LibraryManagementAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogService _logService;

        public BookService(IBookRepository bookRepository, ILogService logService)
        {
            _bookRepository = bookRepository;
            _logService = logService;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try { return await _bookRepository.GetAllAsync(); }
            catch (Exception ex) { _logService.SaveLog("Error fetching books: " + ex.Message); throw; }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            try { return await _bookRepository.GetByIdAsync(id); }
            catch (Exception ex) { _logService.SaveLog("Error fetching book: " + ex.Message); throw; }
        }

        public async Task AddBookAsync(Book book)
        {
            try { await _bookRepository.AddAsync(book); }
            catch (Exception ex) { _logService.SaveLog("Error adding book: " + ex.Message); throw; }
        }

        public async Task UpdateBookAsync(Book book)
        {
            try { await _bookRepository.UpdateAsync(book); }
            catch (Exception ex) { _logService.SaveLog("Error updating book: " + ex.Message); throw; }
        }

        public async Task DeleteBookAsync(int id)
        {
            try { await _bookRepository.DeleteAsync(id); }
            catch (Exception ex) { _logService.SaveLog("Error deleting book: " + ex.Message); throw; }
        }
    }
}