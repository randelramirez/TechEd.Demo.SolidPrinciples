using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TechEd.Demo.SolidPrinciples.Srp
{
    public class FormatConverter
    {
        private readonly DocumentStorage _documentStorage;
        private readonly InputParser _inputParser;
        private readonly DocumentSerializer _documentSerializer;

        public FormatConverter()
        {
            this._documentStorage = new DocumentStorage();
            this._inputParser = new InputParser();
            this._documentSerializer = new DocumentSerializer();
        }

        public bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            string input;

            try
            {
                input = _documentStorage.GetData(sourceFileName);
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            var doc = _inputParser.ParseInput(input);
            var serializedDocument = _documentSerializer.Serialize(doc);

            try
            {
                _documentStorage.SaveData(serializedDocument, targetFileName);
            }
            catch (AccessViolationException)
            {
                return false;
            }

            return true;
        }
    }
}