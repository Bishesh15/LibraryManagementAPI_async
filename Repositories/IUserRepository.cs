using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repositories
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user);
        Task<User> LoginAsync(string email, string password);
    }
}