using System;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace TechEd.Demo.SolidPrinciples.Refactored
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string sourceFileName = "..\\..\\..\\Input Documents\\Document1.xml";
            const string targetFileName = "..\\..\\..\\Output Documents\\Document1.json";

            var sourceFilePath = Path.Combine(Environment.CurrentDirectory, sourceFileName);
            var targetFilePath = Path.Combine(Environment.CurrentDirectory, targetFileName);

            var input = GetInput(sourceFilePath);
            var doc = GetDocument(input);



            Console.WriteLine("{0}\n{1}", doc.Title, doc.Text);
            Console.ReadKey();
        }

        #region Private Helpers

        private static string GetInput(string sourceFilePath)
        {
            string buffer;

            using (var stream = File.Open(sourceFilePath, FileMode.Open))
            using (var streamReader = new StreamReader(stream))
                buffer = streamReader.ReadToEnd();

            return buffer;
        }

        private static Document GetDocument(string input)
        {
            var xdoc = XDocument.Parse(input);

            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            return doc;
        }

        #endregion
    }
}