using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Controllers;

namespace WebApplicationTest
{
    public class CategoriesControllerTest
    {

        [TestMethod]
        public void GetCategoriesOk()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            RegionController controller = new RegionController(logicMock.Object);

            logicMock.Setup(x => x.GetAllCategories()).Returns(It.IsAny<IEnumerable<Category>>());

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<Region>;

            logicMock.VerifyAll();
        }
    }
}
