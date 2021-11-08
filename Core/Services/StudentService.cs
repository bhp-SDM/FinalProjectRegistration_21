using Core.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepo;

        public StudentService(IStudentRepository repo)
        {
            if (repo == null)
            {
                throw new ArgumentException("Student Repository is null");
            }
            studentRepo = repo;
        }

        public void AddStudent(Student s)
        {
            studentRepo.Add(s);
        }

        public List<Student> GetAllStudents()
        {
            throw new System.NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveStudent(Student s)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStudent(Student s)
        {
            throw new System.NotImplementedException();
        }
    }
}
