using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly LibraryDbContext _context;

        public StudentRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
            => await _context.Students.ToListAsync();

        public async Task<Student> GetByIdAsync(int id)
            => await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);

        public async Task AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}