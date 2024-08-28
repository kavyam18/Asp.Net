using RoutingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingWeb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult GetAllStudents()
        {
            var students = Students();
            return View(students);
        }
        public ActionResult GetStudent( int id)
        {
            var student = Students().FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        public ActionResult GetStudentAddress(int id)
        {
            var studentAddress = Students().Where(x => x.Id == id).Select(x => x.Address);
            return View(studentAddress);
        }
        private List<Student> Students()
        {
            return new List<Student>()
            {
                new Student()
                {
                   Id = 1,
                   Name = "Student 1",
                   Class ="First",
                   Address = new Address()
                   {
                       Address1 = "This is student 1 Address",
                       City = "Student 1 City",
                       HomeNumber = "Student 1"
                   }
                },
                new Student()
                {
                   Id = 2,
                   Name = "Student 2",
                   Class ="Two",
                   Address = new Address()
                   {
                       Address1 = "This is student 2 Address",
                       City = "Student 2 City",
                       HomeNumber = "Student 2"
                   }
                },

            };
        }
    }
}