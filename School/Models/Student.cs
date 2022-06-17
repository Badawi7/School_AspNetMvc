using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
  public class Student
  {
    public Student(int id)
    {
      Id = id;
    }

    public int Id { get; }
    public string Name { get; set; }
    public int Age { get; set; }
  }
}
