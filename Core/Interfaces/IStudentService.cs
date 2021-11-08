using Core.Model;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(Student s);
        void UpdateStudent(Student s);
        void RemoveStudent(Student s);
        Student GetStudentById(int id);
        List<Student> GetAllStudents();
    }
}
