using Core.Interfaces;
using Core.Model;
using Core.Services;
using Moq;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class StudentServiceTest
    {
        /// <summary>
        /// Test for creating ad valid StudentService.
        /// </summary>
        [Fact]
        public void CreateStudentService_ValidRepositoty()
        {
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            IStudentService service = null;
            service = new StudentService(mock.Object);
            Assert.NotNull(service);
            Assert.True(service is StudentService);
        }

        /// <summary>
        /// Test for trowing exception if the repository is null.
        /// </summary>
        [Fact]
        public void CreateStudentService_RepositoryIsNull_ThrowsException()
        {
            IStudentService service = null;
            var ex = Assert.Throws<ArgumentException>(() => service = new StudentService(null));
            Assert.Equal("Student Repository is null", ex.Message);
            Assert.Null(service);
        }

        /// <summary>
        /// Test for adding a valid student to the repository.
        /// The student email is optional.
        /// </summary>
        /// <param name = "id" ></ param >
        /// < param name="name"></param>
        /// <param name = "address" ></ param >
        /// < param name="zipcode"></param>
        /// <param name = "city" ></ param >
        /// < param name="email"></param>
        [Theory]
        [InlineData(1, "Name", "Address", 1234, "City", null)]
        [InlineData(1, "Name", "Address", 1234, "City", "abc@mail.com")]
        public void AddStudent_ValidStudent(int id, string name, string address, int zipcode, string city, string email)
        {
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            IStudentService service = new StudentService(mock.Object);
            Student s = new Student(id, name, address, zipcode, city, email);

            service.AddStudent(s);

            mock.Verify(x => x.Add(s), Times.Once);
        }
        /// <summary>
        /// Test for throwing ArgumentException if Student object contains invalid properties.
        /// 1. id must be greater than 0.
        /// 2. Name cannot be null or empty.
        /// 3. Address cannot be null or empty.
        /// 4. Zipcode between [1-9999]
        /// 5. City cannot be null or empty.
        /// 6. Email is optional, but cannot be empty.
        /// </summary>
        /// <param name="id">test id</param>
        /// <param name="name">test name</param>
        /// <param name="address">test address</param>
        /// <param name="zipcode">test zipcode</param>
        /// <param name="city">test city</param>
        /// <param name="email">test email</param>
        /// <param name="errorMessage">error message for exceptino</param>
        [Theory]
        [InlineData(0, "Name", "Address", 1234, "City", "e@mail.dk", "Invalid Id")]         // Id = 0
        [InlineData(-1, "Name", "Address", 1234, "City", null, "Invalid Id")]               // Id is negative
        [InlineData(1, null, "Address", 1234, "City", null, "Name is missing or empty")]    // Name is null
        [InlineData(1, "", "Address", 1234, "City", null, "Name is missing or empty")]      // Name is empty
        [InlineData(1, "Name", null, 1234, "City", null, "Address is missing or empty")]    // Address is null
        [InlineData(1, "Name", "", 0, "City", null, "Address is missing or empty")]         // Address is empty         
        [InlineData(1, "Name", "Address", 0, "City", null, "Invalid Zipcode")]              // Zipcode too low
        [InlineData(1, "Name", "Address", 10000, "City", null, "Invalid Zipcode")]          // Zipcode too high
        [InlineData(1, "Name", "Address", 1234, null, null, "City is missing or empty")]    // City is null
        [InlineData(1, "Name", "Address", 1234, "", null, "City is missing or empty")]      // City is empty
        [InlineData(1, "Name", "Address", 1234, "City", "", "Email is empty")]              // Email is empty

        public void AddStudent_InvalidStudent_ThrowsException(int id, string name, string address, int zipcode, string city, string email, string errorMessage)
        {
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            IStudentService service = new StudentService(mock.Object);
            Student s = new Student(id, name, address, zipcode, city, email);
            
            var ex = Assert.Throws<ArgumentException>(() => service.AddStudent(s));
            
            Assert.Equal(errorMessage, ex.Message);
            mock.Verify((x) => x.Add(s), Times.Never);
        }
        /// <summary>
        /// Test throwing exception if Student object is null.
        /// </summary>
        [Fact]
        public void AddStudent_StudentIsNull_ThrowsException()
        {
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            IStudentService service = new StudentService(mock.Object);

            var ex = Assert.Throws<ArgumentException>(() => service.AddStudent(null));
            
            Assert.Equal("Student is missing", ex.Message);
            mock.Verify(x => x.Add(null), Times.Never);
        }

        [Fact]
        public void UpdateStudent_ExistingStudent()
        {
            Student s = new Student(1, "Aname", "AnAddress", 1234, "ACity");
            
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            mock.Setup(x => x.GetById(s.Id)).Returns(s);

            IStudentService service = new StudentService(mock.Object);
            service.UpdateStudent(s);

            mock.Verify(repo => repo.GetById(s.Id), Times.Once());
            mock.Verify(repo => repo.Update(s), Times.Once());
        }

        [Fact]
        public void UpdateStudent_NonExistingStudent_ThrowsException()
        {
            Student s = new Student(1, "Aname", "AnAddress", 1234, "ACity");
            
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            mock.Setup(x => x.GetById(s.Id)).Returns(() => null);

            IStudentService service = new StudentService(mock.Object);
            
            var ex = Assert.Throws<ArgumentException>(() =>service.UpdateStudent(s));
            
            Assert.Equal("Student does not exist", ex.Message);
            mock.Verify(repo => repo.GetById(s.Id), Times.Once());
            mock.Verify(repo => repo.Update(s), Times.Never());
        }

        [Fact]
        public void UpdateStudent_StudentIsNull_ThrowsException()
        {
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            IStudentService service = new StudentService(mock.Object);
            
            var ex = Assert.Throws<ArgumentException>(() => service.UpdateStudent(null));

            Assert.Equal("Student is missing", ex.Message);           
            mock.Verify(repo => repo.Update(null), Times.Never());
        }
    }
}
