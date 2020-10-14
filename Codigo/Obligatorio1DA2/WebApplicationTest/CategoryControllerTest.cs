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
    [TestClass]
    public class CategoryControllerTest
    {

        [TestMethod]
        public void GetCategoriesOk()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            CategoryController controller = new CategoryController(logicMock.Object);

            Category cat = new Category()
            {
                Name = null,
                TouristicPoints = null
            };
            List<Category> categories = new List<Category>();
            categories.Add(cat);

            logicMock.Setup(x => x.GetAllCategories()).Returns(categories);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<Category>;

            logicMock.VerifyAll();
        }

        [TestMethod]
        public void GetCategoriesException()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            CategoryController controller = new CategoryController(logicMock.Object);

            Category cat = new Category()
            {
                Name = null,
                TouristicPoints = null
            };
            List<Category> categories = new List<Category>();
            categories.Add(cat);

            logicMock.Setup(x => x.GetAllCategories()).Throws(new Exception());

            var result = controller.Get();
            logicMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
