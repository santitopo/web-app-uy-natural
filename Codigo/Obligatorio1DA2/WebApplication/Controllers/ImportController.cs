﻿using System;
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

        [HttpPost]
        public IActionResult GetAvailableImporters([FromBody] IEnumerable<ImportParameter> parameters)
        {
            ImportResult results = new ImportResult();

            List<string> availableImporters = new List<string>();
            string[] filePaths = Directory.GetFiles(this.importPath);
            foreach (string file in filePaths)
            {
                var dllFile = new FileInfo(file);
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
                        try
                        {
                            IImporter instance = (IImporter)Activator.CreateInstance(type);
                            IEnumerable<Lodging> importResult = instance.Import(parameters);
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
                        catch (Exception ex)
                        {
                            //Idea: create list with all the error cases to return at the end.
                        }
                    }
                }

            }

            return Ok(results);

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

        // DEPRECATED
        //private bool SatisfiesInterface(Type t)
        //{
        //    //First, we look for all the interface methods that must be satisfied.
        //    List<Triplete> expectedMethodInfo = new List<Triplete>();

        //    MethodInfo[] expectedMethods = typeof(IImporter).GetMethods();
        //    foreach(MethodInfo method in expectedMethods)
        //    {
        //        ParameterInfo[] args = method.GetParameters();
        //        Triplete methodInfo = new Triplete()
        //        {
        //            methodName = method.Name,
        //            returnType = method.ReturnType.Name,
        //            parameters = method.GetParameters(),
        //            verifies = false,
        //        };

        //        expectedMethodInfo.Add(methodInfo);
        //    }

        //    //Second, we iterate through the methods of the imported type.
        //    foreach (MethodInfo met in t.GetMethods())
        //    {
        //        foreach (ParameterInfo param in met.GetParameters())
        //        {
        //            string.Format("{0} : {1} ", param.Name, param.ParameterType.Name);
        //        }
        //    }
        //    return true;
        //}
        //struct Triplete
        //{
        //    public string methodName;
        //    public string returnType;
        //    public ParameterInfo[] parameters;
        //    public bool verifies;
        //}


    }
}
