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

        NameGenerator fortest = new NameGenerator();  

        [TestMethod]
        public void CanIMakeAnInstanceOfNameGenerator()
        {
            NameGenerator mygenerator = new NameGenerator();

            Assert.IsNotNull(mygenerator);
        }

        [TestMethod]
        public void CanIMakeUniqueStudents()
        {
            
            var student1 = fortest.GenerateRandomStudent();
            var student2 = fortest.GenerateRandomStudent();

            Assert.AreNotEqual(student1, student2);
        }

        
    }
}
