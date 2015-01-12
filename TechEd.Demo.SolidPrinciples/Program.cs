using System;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

// Nouns are classes, verbs are their functions and adjectives are their properties.
// Имена существительные классы, глаголы их функции, а прилогательные их свойства.

// Но если мы хотим разрабатывать систему которая будет гибкой то мы должны смотреть
// (не всегда) на глаголы как на классы.

namespace TechEd.Demo.SolidPrinciples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory,
                "..\\..\\..\\Input Documents\\Document1.xml");

            var targetFileName = Path.Combine(Environment.CurrentDirectory,
                "..\\..\\..\\Output Documents\\Document1.json");

            string input;

            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                input = reader.ReadToEnd();
            }

            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);

            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write(serializedDoc);
                streamWriter.Close();
            }
        }
    }
}