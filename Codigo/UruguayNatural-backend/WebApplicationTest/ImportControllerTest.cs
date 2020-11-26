using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Controllers;
using static WebApplication.Controllers.ImportController;

namespace WebApplicationTest
{
    [TestClass]
    public class ImportControllerTest
    {
        [TestMethod]
        public void Import()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            ImportController controller = new ImportController(adminMock.Object);

            List<ImportParameter> parameters = new List<ImportParameter>();
            ImportParameter a = new ImportParameter()
            {
                Name = "",
                Type = "",
                Value = "",
            };

            LodgingImporterModel model = new LodgingImporterModel()
            {
                DLLName = "..//..//..//..//..//WebApplication//ImporterDLLs//DummyDLL//Dummy",
                ImporterName = "DummyImporter",
                Parameters = parameters,
            };

            adminMock.Setup(x => x.AddReflectionLodging(It.IsAny<Lodging>())).Returns(It.IsAny<Lodging>());

            var result = controller.Import(model);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as ImportResult;

            Assert.AreEqual(1, value.Imported.Count);
            Assert.AreEqual("DummyLodging", value.Imported[0].Name);

            adminMock.VerifyAll();
        }


        [TestMethod]
        public void GetAvailableLodgingImporters()
        {
            //This test will work if the folder ImporterDLLs exists in '@..//..//..//ImporterDLLs' from the location where it is running.
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            ImportController controller = new ImportController(adminMock.Object);

            var result = controller.GetAvailableLodgingImporters();
            var okResult = result as BadRequestResult;

            adminMock.VerifyAll();
        }
    }
}
