using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechEd.Demo.SolidPrinciples.Srp
{
    public class FormatConverter
    {
        private readonly DocumentStorage _documentStorage;

        public FormatConverter()
        {
            this._documentStorage = new DocumentStorage();
        }

        public bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            string input;

            try
            {
                input = this._documentStorage.GetData(sourceFileName);
            }
            catch (FileNotFoundException)
            {
                return false;
            }



            return true;
        }
    }

    public class DocumentStorage
    {
        public string GetData(string fileName)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException();

            using (var stream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(stream))
                return streamReader.ReadToEnd();
        }
    }
}