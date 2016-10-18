using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class NameGenerator
    {
        // This class should be used to generate random names and Majors for Students.

        public  List<string> StudentFirstNames { get; set; }
      public  List<string> StudentLastNames { get; set; }
      public  List<string> StudentMajors { get; set; }
        Random newrandom = new Random();

        public NameGenerator()
        {
             StudentFirstNames = new List<string>() { "Tom", "LeBron", "Ryan", "Andrew", "Bria", "Kate", "Nicole", "Odigene", "Jill", "Callan" };

             StudentLastNames = new List<string>() { "Brady", "James", "Reynolds", "Randle", "Carey", "Williams", "Ahima", "Joseph", "Valentine", "Morrison" };

            StudentMajors = new List<string>() { "English", "Finance", "Biology", "Chemistry", "Computer Science", "Information Systems", "Psychology", "English", "Spanish", "Physical Education" };

        }

        public Student GenerateRandomStudent()
        {
            Student randomstudent = new Student(); 

            int firstnameIndex = newrandom.Next(0, StudentFirstNames.Count);
            int lastnameIndex = newrandom.Next(0, StudentLastNames.Count);
            int majorIndex = newrandom.Next(0, StudentMajors.Count);

            randomstudent.FirstName = StudentFirstNames[firstnameIndex];
            randomstudent.LastName = StudentLastNames[lastnameIndex];
            randomstudent.Major = StudentMajors[majorIndex];

            return randomstudent;
        }

        // This is NOT your Repository
        // All methods should be Unit Tested :)
    }
}