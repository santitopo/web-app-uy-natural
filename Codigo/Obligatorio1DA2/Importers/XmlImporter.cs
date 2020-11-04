using System;
using System.Collections.Generic;
using Domain;
using LogicInterface;

namespace Importers
{
    public class XmlImporter : IImporter
    {
        public string GetImportedName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImportParameter> GetParameters()
        {
            throw new NotImplementedException();
        }

        public ImportResult Import(IEnumerable<ImportParameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
