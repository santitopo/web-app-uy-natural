using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface IImporter
    {
        string GetImportedName();
        ImportResult Import(IEnumerable<ImportParameter> parameters);
        IEnumerable<ImportParameter> GetParameters();
    }

    public class ImportResult
    {
        public IEnumerable<Lodging> Imported { get; set; }
        public IEnumerable<Lodging> NotImported { get; set; }
    }

    public class ImportParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; } // File, tect, int, date, etc...
    }
}
