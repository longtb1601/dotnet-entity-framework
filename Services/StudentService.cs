using System.Collections.Generic;
using System.Linq;
using Entity_Framework.Models;

namespace Entity_Framework.Services
{
    public class StudentService : IStudentService
    {
        private StudentContext _studentContext;
        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public List<Student> GetAll()
        {
            return _studentContext.Students.ToList();
        }

        public Student GetOne(int id)
        {
            var student = _studentContext.Students.FirstOrDefault(s => s.StudentId == id);

            return student;
        }

        public void Create(Student student)
        {
            _studentContext.Add<Student>(student);

            _studentContext.SaveChanges();
        }

        public void Delete(Student student)
        {
            _studentContext.Remove(student);

            _studentContext.SaveChanges();
        }

        public void Edit(int id, Student student)
        {
            var studentEdit = _studentContext.Students.FirstOrDefault(s => s.StudentId == id);

            studentEdit.FirstName = student.FirstName;
            studentEdit.LastName = student.LastName;
            studentEdit.State = student.State;
            studentEdit.City = student.City;

            _studentContext.SaveChanges();
        }
    }
}