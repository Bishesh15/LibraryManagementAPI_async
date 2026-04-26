using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
    }
}