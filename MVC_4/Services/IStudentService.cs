using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVC_4.Models;

namespace MVC_4.Services
{
    public interface IStudentService
    {
        IList<Student> GetAllStudents();
        Student GetStudent(int id);
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        Student DeleteStudent(int id);
    }
}
