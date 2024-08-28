using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOExample
{
    class Animal
    {
        public virtual void eat()
        {
            Console.WriteLine("Eating");
        }
    }
    class Cat : Animal
    {
        public override void eat()
        {
            Console.WriteLine("Cat eating Cookies");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.eat();
            Cat cat = new Cat();
            cat.eat();
            Console.ReadLine();
        }
    }
}
