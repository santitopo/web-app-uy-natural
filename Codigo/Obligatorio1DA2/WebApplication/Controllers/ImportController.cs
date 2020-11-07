using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Controllers
{
    [Route("/imports")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private string importPath { get; set; }

        private readonly ILodgingLogic lodgingLogic;
        private readonly ISearchLogic searchLogic;
        private readonly IAdminLogic adminLogic;

        public ImportController(ILodgingLogic lodgingLogic, IAdminLogic adminLogic)
        {
            this.lodgingLogic = lodgingLogic;
            this.adminLogic = adminLogic;
            importPath = "@..//..//..//ImporterDLLs";
        }

        [HttpGet]
        public IActionResult GetAvailableLodgingImporters()
        {
            try
            {
                List<LodgingImporterModel> availableImporters = new List<LodgingImporterModel>();
                string[] filePaths = Directory.GetFiles(this.importPath);
                foreach (string file in filePaths)
                {
                    try
                    {
                        //Convert file into assembly
                        Assembly assembly = Assembly.UnsafeLoadFrom(file);
                        bool satisfies = false;

                        //If conversion was successful, we obtain all the classes in the dll (Types). 
                        //Now we check if some class in the DLL implements the interface we want
                        foreach (Type type in assembly.GetTypes())
                        {
                            //Check if it satisifies the interface
                            if (typeof(IImporter).IsAssignableFrom(type))
                            {
                                IImporter instance = (IImporter)Activator.CreateInstance(type);
                                LodgingImporterModel model = new LodgingImporterModel()
                                {
                                    Parameters = instance.GetParameters(),
                                    ImporterName = instance.GetImporterName(),
                                    DLLName = assembly.GetName().Name,
                                };
                                availableImporters.Add(model);
                            }
                        }
                    }
                    catch (Exception) { }
                }
                return Ok(availableImporters);
            }
            catch (Exception)
            {
                return BadRequest("Error cargando los dll disponibles");
            }
        }


        [HttpPost]
        public IActionResult Import([FromBody] LodgingImporterModel importerModel)
        {
            try
            {
                ImportResult results = new ImportResult();

                string file = this.importPath + "//" + importerModel.DLLName;

                //Convert file into assembly
                Assembly assembly = Assembly.UnsafeLoadFrom(file);

                //If conversion was successful, we obtain all the classes in the dll (Types). 
                //Now we check if some class in the DLL implements the interface we want

                foreach (Type type in assembly.GetTypes())
                {
                    //Check if it satisifies the interface
                    if (typeof(IImporter).IsAssignableFrom(type))
                    {
                        //New importer instance
                        IImporter instance = (IImporter)Activator.CreateInstance(type);
                        IEnumerable<Lodging> importResult = instance.Import(importerModel.Parameters);
                        foreach (Lodging lodging in importResult)
                        {
                            //Try to add lodging to system.
                            try
                            {
                                adminLogic.AddReflectionLodging(lodging);
                                results.Imported.Add(lodging);
                            }
                            catch (InvalidOperationException e)
                            {
                                Tuple err = new Tuple()
                                {
                                    Lodging = lodging,
                                    Reason = e.Message
                                };
                                results.NotImported.Add(err);
                            }
                            catch (Exception)
                            {
                                Tuple err = new Tuple()
                                {
                                    Lodging = lodging,
                                    Reason = "Error no identificado",
                                };
                                results.NotImported.Add(err);
                            }
                        }

                    }
                }
                return Ok(results);
            }
            catch (Exception e)
            {
                return BadRequest("Error en la importación");
            }
        }


        public class ImportResult
        {
            public List<Lodging> Imported { get; set; }
            public List<Tuple> NotImported { get; set; }

            public ImportResult()
            {
                Imported = new List<Lodging>();
                NotImported = new List<Tuple>();
            }
        }

        public class Tuple
        {
            public Lodging Lodging { get; set; }
            public string Reason { get; set; }


        }

        public class LodgingImporterModel
        {
            public IEnumerable<ImportParameter> Parameters { get; set; }
            public string ImporterName { get; set; }
            public string DLLName { get; set; }
        }

    }
}
