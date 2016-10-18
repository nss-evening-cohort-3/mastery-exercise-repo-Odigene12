using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using RepoQuiz.Models;
using System.Linq;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class NameGeneratorTests
    {
        Mock<StudentContext> myContext { get; set; }
        List<Student> StudentList = new List<Student>();

        StudentRepository repo { get; set; }
        NameGenerator fortest { get; set; }




        [TestInitialize]
        public void Initialize()
        {
            StudentList = new List<Student>() {
            new Student {FirstName = "David", LastName = "Beckham", Major = "Fashion" },
            new Student {FirstName = "Ryan", LastName = "Giggs", Major = "Design" },
            new Student {FirstName = "Roberto", LastName = "Carlos", Major = "Physical Education" }
                 }; //Fake
            repo = new StudentRepository(myContext.Object);
            fortest = new NameGenerator(myContext.Object);
   
        }

        
    }
}
