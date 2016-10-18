using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace RepoQuiz.Tests.DAL
{
   

    [TestClass]
    public class StudentRepositoryTests
    {
        Mock<StudentContext> myContext { get; set; }
        Mock<DbSet<Student>> mockStudents { get; set; }
        List<Student> StudentList = new List<Student>();
    
        StudentRepository repo { get; set; }


        public void ConnectingToDatabase()
        {
            var queryStudents = StudentList.AsQueryable();

            //Lie to LINQ make it think that our new Queryable List is a Database table.
            mockStudents.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(queryStudents.Provider);
            mockStudents.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(queryStudents.Expression);
            mockStudents.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(queryStudents.ElementType);
            mockStudents.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => (queryStudents.GetEnumerator()));

            //Here, I am setting up the Mock Context to return my DbSet.
            myContext.Setup(c => c.Students).Returns(mockStudents.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            myContext = new Mock<StudentContext>();
            mockStudents = new Mock<DbSet<Student>>();
            StudentList = new List<Student>() {
            new Student {FirstName = "David", LastName = "Beckham", Major = "Fashion" },
            new Student {FirstName = "Ryan", LastName = "Giggs", Major = "Design" }
                 }; //Fake
            repo = new StudentRepository(myContext.Object);
            ConnectingToDatabase();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null; //
        }

        [TestMethod]
        public void CanIMakeAnInstanceOfStudent()
        {
            Mock<DbSet<Student>> mystudent = new Mock<DbSet<Student>>();
            Assert.IsNotNull(mystudent);
        }

        [TestMethod]
        public void CanIMakeANewRepository()
        {
            myContext = new Mock<StudentContext>();
            StudentRepository repo = new StudentRepository(myContext.Object);
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void CanIGetStudents()
        {
            List<Student> mystudents = repo.GetStudents();
            Assert.AreEqual(mystudents.Count, 2);
        }

        [TestMethod]
        public void CanIGetStudentByFirstName()
        {
            Student foundstudent = repo.GetStudents("David");
            Assert.AreEqual(foundstudent.FirstName, "David");
        }

        [TestMethod]
        public void CanIGetAllStudentFirstNames()
        { 
            List<string> firstnames = repo.GetAllFirstNames();
            CollectionAssert.AreEqual(firstnames, new List<string> { "David", "Ryan" });
        }

        [TestMethod]
        public void CanIGetAllStudentLastNames()
        {
            List<string> lastnames = repo.GetAllLastNames();
            CollectionAssert.AreEqual(lastnames, new List<string> { "Beckham", "Giggs" });
        }

        [TestMethod]
        public void CanIGetAllStudentMajors()
        {
            List<string> majors = repo.GetAllMajors();
            CollectionAssert.AreEqual(majors, new List<string> { "Fashion", "Design" });
        }
    }
}
