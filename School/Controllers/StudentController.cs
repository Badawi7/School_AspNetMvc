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
    static readonly List<Student> students = new List<Student> {
        new Student() {Id = 1, Name = "Chris", Age = 15},
        new Student() {Id = 2, Name = "Leon", Age = 14},
        new Student() {Id = 3, Name = "Albert", Age = 15}
      };

    private int GetNewId()
    {
      return students.Max(s => s.Id) + 1;
    }

    // GET: Student
    public ActionResult Index()
    {
      return View(students);
    }

    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return View();
      }
      else
      {
        var student = students.Find(s => s.Id == id);
        return View(student);
      }
    }

    [HttpPost]
    public ActionResult Edit(Student student)
    {
      System.Diagnostics.Debugger.Break();
      if (student.Id == 0)
      {
        student.Id = GetNewId();
        students.Add(student);
      }
      else
      {
        var targetStudent = students.Find(s => s.Id == student.Id);
        targetStudent.Name = student.Name;
        targetStudent.Age = student.Age;
      }
      return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
      return RedirectToAction("Edit");
    }
  }
}
