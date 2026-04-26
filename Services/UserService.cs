using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using LibraryManagementAPI.Utilities;

namespace LibraryManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogService _logService;

        public UserService(IUserRepository userRepository, ILogService logService)
        {
            _userRepository = userRepository;
            _logService = logService;
        }

        public async Task RegisterAsync(User user)
        {
            try { await _userRepository.RegisterAsync(user); }
            catch (Exception ex) { _logService.SaveLog("Error registering user: " + ex.Message); throw; }
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            try { return await _userRepository.LoginAsync(email, password); }
            catch (Exception ex) { _logService.SaveLog("Error logging in: " + ex.Message); throw; }
        }
    }
}