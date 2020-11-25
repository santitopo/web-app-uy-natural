using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface IImporter
    {
        string GetImporterName();
        IEnumerable<Lodging> Import(IEnumerable<ImportParameter> parameters);
        IEnumerable<ImportParameter> GetParameters();
    }


    public class ImportParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; } 
    }
}
