using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class StudentService
    {
        public IStudent Student;

        public StudentService(IStudent Student) 
        {
            this.Student = Student; 
        }
        public List<Student> GetAllStudents()
        {
            return Student.SelectAllStudents();
        }
    }
}
