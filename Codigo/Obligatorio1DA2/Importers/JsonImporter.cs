using System;
using System.Collections.Generic;
using Domain;
using LogicInterface;
using System.Linq;
using System.Text.Json;

namespace Importers
{
    public class JsonImporter : IImporter
    {
        public string GetImportedName()
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
            return parameters;

        }

        public ImportResult Import(IEnumerable<ImportParameter> parameters)
        {
            ImportResult ret = new ImportResult();
            List<ImportParameter> p = parameters.ToList();
            string jsonContent =
                System.IO.File.ReadAllText(p[0].Value);
            List<Lodging> imported = JsonSerializer.Deserialize<List<Lodging>>(jsonContent);

            ret.Imported = imported;
            return ret;
        }
    }
}
