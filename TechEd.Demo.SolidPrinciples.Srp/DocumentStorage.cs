using System;
using System.IO;

namespace TechEd.Demo.SolidPrinciples.Srp
{
    public class DocumentStorage
    {
        public string GetData(string fileName)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException();

            using (var stream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(stream))
                return streamReader.ReadToEnd();
        }

        public void SaveData(string serializedDocument, string targetFileName)
        {
            try
            {
                using (var stream = new FileStream(targetFileName, FileMode.OpenOrCreate))
                using (var streamWriter = new StreamWriter(stream))
                    streamWriter.Write(serializedDocument);
            }
            catch (Exception)
            {
                throw new AccessViolationException();
            }
        }
    }
}