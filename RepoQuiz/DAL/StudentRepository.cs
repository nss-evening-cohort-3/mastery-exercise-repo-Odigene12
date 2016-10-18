using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;


namespace RepoQuiz.DAL
{
    public class StudentRepository
    {
        private StudentContext Context { get; set; }

        public StudentRepository()
        {
            Context = new StudentContext();
        }

        public StudentRepository(StudentContext context)
        {
            Context = context;
        }

        public List<Student> GetStudents()
        {
          
            return Context.Students.ToList();
        }

        public Student GetStudents(string firstname)
        {
             Student foundstudent = Context.Students.First(student => student.FirstName.ToLower() == firstname.ToLower());

            return foundstudent;
        }

       public List<string> GetAllFirstNames()
        {
            List<string> FirstNames = Context.Students.Select(students => students.FirstName).ToList();

            return FirstNames;
        }

        public List<string> GetAllLastNames()
        {
            List<string> LastNames = Context.Students.Select(students => students.LastName).ToList();

            return LastNames;
        }

        public List<string> GetAllMajors()
        {
            List<string> Majors = Context.Students.Select(students => students.Major).ToList();

            return Majors;
        }
    }
}