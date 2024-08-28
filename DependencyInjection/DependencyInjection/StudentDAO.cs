using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class StudentDAO : IStudent
    {
        public List<Student> SelectAllStudents()
        {
            List<Student> list = new List<Student>
            {
                new Student() { Id = 1, Name = "Dhanu", Email = "dhanu@gmail.com", Department = "Cs" },
                new Student() { Id = 2, Name = "Gokul", Email = "gokul@gmail.com", Department = "EEE" },
                new Student(){ Id = 3, Name = "Divya", Email = "divya@gmail.com", Department ="EC" }
            };
            return list;
        }
    }
}
