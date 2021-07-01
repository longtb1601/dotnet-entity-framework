using System.Collections.Generic;
using Entity_Framework.Models;

namespace Entity_Framework.Services
{
    public interface IStudentService
    {
        Student GetOne(int id);
        List<Student> GetAll();
        void Create(Student model);
        void Edit(int id, Student model);
        void Delete(int id);
    }
}