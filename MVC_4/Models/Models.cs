using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_4.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }

    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
    }
}