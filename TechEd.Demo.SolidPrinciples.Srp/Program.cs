using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechEd.Demo.SolidPrinciples.Srp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Input Documents\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Output Documents\\Document1.json");

            var formatConverter = new FormatConverter();
            if (formatConverter.ConvertFormat(sourceFileName, targetFileName)) return;

            Console.WriteLine("Conversion faild...");
            Console.ReadKey();
        }
    }
}