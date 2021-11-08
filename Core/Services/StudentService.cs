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
            ThrowIfInvalidStudent(s);
            studentRepo.Add(s);
        }

        private void ThrowIfInvalidStudent(Student s)
        {
            if (s == null)
                throw new ArgumentException("Student is missing");
            if (s.Id <= 0)
                throw new ArgumentException("Invalid Id");
            if (s.Name == null || s.Name == "")
                throw new ArgumentException("Name is missing or empty");
            if (s.Address == null || s.Address == "")
                throw new ArgumentException("Address is missing or empty");
            if (s.Zipcode < 1 || s.Zipcode > 9999)
                throw new ArgumentException("Invalid Zipcode");
            if (s.City == null || s.City == "")
                throw new ArgumentException("City is missing or empty");
            if (s.Email != null && s.Email == "")
                throw new ArgumentException("Email is empty");
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
