using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Employee
    {
        private int Employee_id { get; set; }
        private string name { get ; set; }
        private string email { get; set ; }
        private string dept { get ; set ; }
        private double salary { get; set; }

        public  Employee(int Employee_id, string name, string email, string dept, double salary) { 
            this.Employee_id = Employee_id;
            this.name = name;
            this.email = email;
            this.dept = dept;
            this.salary = salary;
        }
        public String display()
        {
            return("Employee_id :"+Employee_id+" "+"name:"+name+" "+"email:"+email+" "
                +"dept:"+dept+" "+"salary:"+salary);
        }
    }
}
