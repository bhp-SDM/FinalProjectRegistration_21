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
        public void CreateStudentServicevalidRepositoty()
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
        public void CreateStudentServiceRepositoryIsNullThrowsException()
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
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="city"></param>
        /// <param name="email"></param>
        [Theory]
        [InlineData(1, "Name", "Address", 1234, "City", null)]
        [InlineData(1, "Name", "Address", 1234, "City", "abc@mail.com")]
        public void AddStudentIsValidStudent(int id, string name, string address, int zipcode, string city, string email)
        {
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            IStudentService service = new StudentService(mock.Object);
            Student s = new Student(id, name, address, zipcode, city, email);

            service.AddStudent(s);

            mock.Verify(x => x.Add(s), Times.Once);
        }

        //[Theory]
        //[InlineData(0, "Name", "Address", 1234, "City")]
        //[InlineData(-1, "Name", "Address", 1234, "City")]
        //[InlineData(1, null, "Address", 1234, "City")]
        //[InlineData(1, "", "Address", 1234, "City")]
        //[InlineData(1, "Name", null, 1234, "City")]
        //[InlineData(1, "Name", "", 0, "City")]
        //[InlineData(1, "Name", "Address", 10000, "City")]
        //[InlineData(1, "Name", "Address", 1234, null)]
        //[InlineData(1, "Name", "Address", 1234, "")]
        //public void AddStudentInvalidStudentThrowsException(int id, string name, string address, int zipcode, string city)
        //{
        //    Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
        //    IStudentService service = new StudentService(mock.Object);
        //    Student s = new Student(id, name, address, zipcode, city, null);
        //    var ex = Assert.Throws<ArgumentException>(() => service.AddStudent(s));
            
        //    mock.Verify((x) => x.Add(s), Times.Never);
        //}
    }
}
