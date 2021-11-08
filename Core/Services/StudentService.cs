using Core.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepo;

     /// <summary>
     /// creates a new StudentService for the attached repository (repo).
     /// If the repo is null an ArgumentException is thrown 
     /// and the StudentService is not created.
     /// </summary>
     /// <param name="repo">The Student Repository</param>
        public StudentService(IStudentRepository repo)
        {
            if (repo == null)
            {
                throw new ArgumentException("Student Repository is null");
            }
            studentRepo = repo;
        }

        /// <summary>
        /// Adds the student, s, to the Student Repository.
        /// </summary>
        /// <param name="s">The Student to add</param>
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
