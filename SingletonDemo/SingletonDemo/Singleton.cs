using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class Singleton
    {
        private static int Counter = 0;
        private static Singleton instance = null;

        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
        private Singleton() 
        {
            Counter++;
            Console.WriteLine("Counter Value" + Counter.ToString());
        }
        public void PrintDetails(String message)
        {
            Console.WriteLine(message);
        }
        //public class DerivedSingleton : Singleton
        //{

        //}

    }
}
