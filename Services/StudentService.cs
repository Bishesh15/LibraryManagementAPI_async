using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using LibraryManagementAPI.Utilities;

namespace LibraryManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogService _logService;

        public StudentService(IStudentRepository studentRepository, ILogService logService)
        {
            _studentRepository = studentRepository;
            _logService = logService;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            try { return await _studentRepository.GetAllAsync(); }
            catch (Exception ex) { _logService.SaveLog("Error fetching students: " + ex.Message); throw; }
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            try { return await _studentRepository.GetByIdAsync(id); }
            catch (Exception ex) { _logService.SaveLog("Error fetching student: " + ex.Message); throw; }
        }

        public async Task AddStudentAsync(Student student)
        {
            try { await _studentRepository.AddAsync(student); }
            catch (Exception ex) { _logService.SaveLog("Error adding student: " + ex.Message); throw; }
        }

        public async Task UpdateStudentAsync(Student student)
        {
            try { await _studentRepository.UpdateAsync(student); }
            catch (Exception ex) { _logService.SaveLog("Error updating student: " + ex.Message); throw; }
        }
    }
}