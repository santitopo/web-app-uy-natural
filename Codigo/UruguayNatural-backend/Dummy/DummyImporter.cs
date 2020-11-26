using System;
using System.Collections.Generic;
using Domain;
using LogicInterface;
using System.Linq;
using System.Text.Json;

namespace Dummy
{
    public class DummyImporter : IImporter
    {
        public string GetImporterName()
        {
            return "DummyImporter";
        }

        public IEnumerable<ImportParameter> GetParameters()
        {
            List<ImportParameter> parameters = new List<ImportParameter>();
            ImportParameter file = new ImportParameter()
            {
                Name = "DummyImporterRoute",
                Type = "",
            };
            parameters.Add(file);
            return parameters;

        }

        public IEnumerable<Lodging> Import(IEnumerable<ImportParameter> parameters)
        {
            List<Lodging> imported = new List<Lodging>();
            Lodging l = new Lodging()
            {
                Name = "DummyLodging",
            };
            imported.Add(l);
            return imported;
        }
    }
}
