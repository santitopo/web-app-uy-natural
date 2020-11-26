using System;
using System.Collections.Generic;
using Domain;
using LogicInterface;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Xml.Serialization;

namespace XmlImporter
{
    public class XmlImporter : IImporter
    {
        public string GetImporterName()
        {
            //Has to match the class name
            return "XmlImporter";
        }

        public IEnumerable<ImportParameter> GetParameters()
        {
            List<ImportParameter> parameters = new List<ImportParameter>();
            ImportParameter file = new ImportParameter()
            {
                Name = "XmlRoute",
                Type = "File",
            };
            parameters.Add(file);
            return parameters;

        }

        public IEnumerable<Lodging> Import(IEnumerable<ImportParameter> parameters)
        {
            List<ImportParameter> p = parameters.ToList();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lodging>)); 
 
            using (StreamReader writer = new StreamReader(p[0].Value))
            {
                return (List<Lodging>)xmlSerializer.Deserialize(writer);
            }
        }
    }
}
