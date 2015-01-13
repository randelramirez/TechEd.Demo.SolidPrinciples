using System;
using Newtonsoft.Json;

namespace TechEd.Demo.SolidPrinciples.Srp
{
    public class DocumentSerializer
    {
        public string Serialize(Document document)
        {
            var serializedDoc = JsonConvert.SerializeObject(document);

            return serializedDoc;
        } 
    }
}