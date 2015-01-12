using System;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

// Nouns are classes, verbs are their functions and adjectives are their properties.
// Имена существительные классы, глаголы их функции, а прилогательные их свойства.

// Но если мы хотим разрабатывать систему которая будет гибкой то мы должны смотреть
// (не всегда) на глаголы как на классы.

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
            var serializedDoc = SerializeDocument(doc);
            SaveDocument(serializedDoc, targetFilePath);
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

            return new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
        }

        private static string SerializeDocument(Document doc)
        {
            return JsonConvert.SerializeObject(doc);
        }

        private static void SaveDocument(string serializedDoc, string targetFilePath)
        {
            using (var stream = new FileStream(targetFilePath, FileMode.Create))
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write(serializedDoc);
            }
        }

        #endregion
    }
}