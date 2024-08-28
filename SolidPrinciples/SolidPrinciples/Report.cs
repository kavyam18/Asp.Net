using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class Report
    {
        public void GenerateReport() 
        {
            Console.WriteLine("Generate Student report");
        }
    }
    public class SaveReport
    {
        public void Save()
        {
            Console.WriteLine("Save the report");
        }
    }
}
