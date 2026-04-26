using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services
{
    public interface IUserService
    {
        Task RegisterAsync(User user);
        Task<User> LoginAsync(string email, string password);
    }
}