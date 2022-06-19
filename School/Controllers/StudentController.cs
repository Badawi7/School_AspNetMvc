using School.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public static ValidationResult UniqueName(string name, ValidationContext context)
    {
      if (name == null) return ValidationResult.Success;
      var student = (Student)context.ObjectInstance;
      var nameIsDuplicated = students
        .Where(s => s.Id != student.Id)
        .Select(s => s.Name.ToLower())
        .Contains(name.ToLower());
      if (nameIsDuplicated)
      {
        return new ValidationResult("Name already exists in database.");
      }
      else
      {
        return ValidationResult.Success;
      }
    }

    static int GetNewId()
    {
      return students.Count == 0 ? 1 : students.Max(s => s.Id) + 1;
    }

    // GET: Student
    public ActionResult Index()
    {
      ViewData["studentCount"] = students.Count;
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
      if (ModelState.IsValid)
      {
        if (student.Id == 0)
        {
          student.Id = GetNewId();
          student.Name = student.Name.Trim();
          students.Add(student);
        }
        else
        {
          var targetStudent = students.Find(s => s.Id == student.Id);
          targetStudent.Name = student.Name.Trim();
          targetStudent.Age = student.Age;
        }
        return RedirectToAction("Index");
      }

      return View(student);
    }

    public ActionResult Create()
    {
      return RedirectToAction("Edit");
    }

    public ActionResult Delete(int id)
    {
      var student = students.Find(s => s.Id == id);
      return View(student);
    }

    [HttpPost]
    public ActionResult Delete(Student student)
    {
      var index = students.FindIndex(s => s.Id == student.Id);
      if (index > -1) students.RemoveAt(index);
      return RedirectToAction("Index");
    }

  }
}
