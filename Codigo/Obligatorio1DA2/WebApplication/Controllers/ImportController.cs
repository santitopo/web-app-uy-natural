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
            importPath = "@..//..//..//..//DLLsDeImportacion";
        }

        public IActionResult GetAvailableImporters([FromBody] IEnumerable<ImportParameter> parameters)
        {
            List<string> availableImporters = new List<string>();
            string[] filePaths = Directory.GetFiles(this.importPath);
            foreach (string file in filePaths)
            {
                var dllFile = new FileInfo(file);
                //Convert file into assembly
                Assembly assembly = Assembly.Load(dllFile.FullName);

                //If conversion was successful, we obtain all the
                //classes in the dll (Types). 
                //Now we check if some implements the interface we want

                foreach (Type type in assembly.GetTypes())
                {
                    //Check if it satisifies the interface
                    if (SatisfiesInterface(type))
                    {
                        //New importer instance
                        try
                        {
                            IImporter instance = (IImporter)Activator.CreateInstance(type);
                            ImportResult lodgings = instance.Import(parameters);
                            foreach (Lodging lodging in lodgings.Imported)
                            {
                                try
                                {

                                    if (!searchLogic.GetAllTPoints().Any(x => x.Name.Equals(lodging.TouristicPoint.Name)))
                                    {
                                        //If the tpoint doesnt exist, then we create it passing regionId and categoriesId...
                                        TouristicPoint newTpoint = lodging.TouristicPoint;
                                        List<int> categories = new List<int>();
                                        newTpoint.Categories.ForEach(x => categories.Add(x.CategoryId));

                                        //We assume that region and categories exist (and have the correct ids)

                                        adminLogic.AddTouristicPoint(newTpoint, newTpoint.Region.Id, categories.ToArray());
                                    }

                                    adminLogic.AddLodging(lodging, lodging.TouristicPoint.Id);
                                }
                                catch (Exception e)
                                {
                                    //Idea: create list with all the error cases to return at the end.
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //Idea: create list with all the error cases to return at the end.
                        }
                    }
                }

            }

            return Ok();

        }

        private bool SatisfiesInterface(Type t)
        {
            throw new NotImplementedException();
        }

    }
}
