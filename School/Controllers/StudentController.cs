using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
  public class StudentController : Controller
  {
    // GET: Student
    public ActionResult Index()
    {
      Student[] students = {
        new Student(1) {Name = "Chris", Age = 15},
        new Student(2) {Name = "Leon", Age = 14},
        new Student(3) {Name = "Albert", Age = 15}
      };
      return View(students);
    }
  }
}
