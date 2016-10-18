using RepoQuiz.DAL;
using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepoQuiz.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository repo = new StudentRepository();
        NameGenerator randomizer = new NameGenerator();
        // GET: Student
        public ActionResult Index()
        {
            List<Student> mystudents = repo.GetStudents();
            ViewBag.Students = mystudents;
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
