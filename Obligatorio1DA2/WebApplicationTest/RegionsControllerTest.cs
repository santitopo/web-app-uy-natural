using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WebApplication.Controllers;

namespace WebApplicationTest
{
    [TestClass]
    public class RegionsControllerTest
    {
        [TestMethod]
        public void GetRegionsOk()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            RegionsController controller = new RegionsController(logicMock.Object);
            
            logicMock.Setup(x => x.GetAllRegions()).Returns(It.IsAny<IEnumerable<Region>>());

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<Region>;

            logicMock.VerifyAll();
        }


    }
}
