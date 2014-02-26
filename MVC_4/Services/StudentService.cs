using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MVC_4.Models;

namespace MVC_4.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext db = new StudentContext();

        public IList<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
                return student;
            throw new Exception("Student not found");
        }

        public Student AddStudent(Student student)
        {
            //db.Students.Find(student.Id);//already exist
            var addedStudent= db.Students.Add(student);
             db.SaveChanges();
             return addedStudent;
        }

        public Student UpdateStudent(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return student;
        }

        public Student DeleteStudent(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return student;
        }
    }
}