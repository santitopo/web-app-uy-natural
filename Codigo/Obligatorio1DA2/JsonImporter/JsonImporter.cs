using System;
using System.Collections.Generic;
using Domain;
using LogicInterface;
using System.Linq;
using System.Text.Json;

namespace JsonImporter
{
    public class JsonImporter : IImporter
    {
        public string GetImporterName()
        {
            return "JsonImporter";
        }

        public IEnumerable<ImportParameter> GetParameters()
        {
            List<ImportParameter> parameters = new List<ImportParameter>();
            ImportParameter file = new ImportParameter()
            {
                Name = "JsonRoute",
                Type = "File",
            };
            parameters.Add(file);
            return parameters;

        }

        public IEnumerable<Lodging> Import(IEnumerable<ImportParameter> parameters)
        {
            List<ImportParameter> p = parameters.ToList();
            string jsonContent =
                System.IO.File.ReadAllText(p[0].Value);
            List<Lodging> imported = JsonSerializer.Deserialize<List<Lodging>>(jsonContent);
            return imported;
        }
    }
}
