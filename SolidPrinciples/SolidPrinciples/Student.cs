using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Student : IRead , IWrite , IPlay
    {
        public void Read()
        {
            Console.WriteLine("Student is reading a book");
        }
        public void Write()
        {
            Console.WriteLine("Student Writing a Novel");
        }
        public void Game()
        {
            Console.WriteLine("Students won the cricket");
        }
    }
}
