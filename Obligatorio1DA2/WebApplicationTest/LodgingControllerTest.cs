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

namespace WebApplicationTest
{
    [TestClass]
    public class LodgingControllerTest
    {
        [TestMethod]
        public void PostOk()
        {
            var mock2 = new Mock<ILodgingLogic>(MockBehavior.Strict);
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            LodgingController controller = new LodgingController(null, adminMock.Object);

            LodgingModel lodgingModel = new LodgingModel()
            {
                Name = "lodging1",
            };

            Lodging lodging = new Lodging()
            {
                Name = "lodging1",
            };

            adminMock.Setup(x => x.AddLodging(It.IsAny<Lodging>(), It.IsAny<int>())).Returns(lodging);
            string token = "123";

            var result = controller.Post(token, lodgingModel);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as Lodging;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void InvalidPost()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(null, adminMock.Object);

            Lodging nullLodging = null;

            LodgingModel lodgingModel = new LodgingModel()
            {
                Name = "lodging1",
            };

            adminMock.Setup(x => x.AddLodging(It.IsAny<Lodging>(), It.IsAny<int>())).
                Throws(new InvalidOperationException("Ya existe un hospedaje con ese nombre y direccion"));
            string token = "123";

            var result = controller.Post(token, lodgingModel);
            var response = result as ObjectResult;
            Assert.AreEqual(400, response.StatusCode);

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteOK()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(null, adminMock.Object);

            adminMock.Setup(x => x.RemoveLodging(It.IsAny<int>()));
            string token = "123";

            var result = controller.Delete(token, 1);
            var okResult = result as OkObjectResult;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteFailNotExists()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(null, adminMock.Object);

            adminMock.Setup(x => x.RemoveLodging(It.IsAny<int>())).Throws(new InvalidOperationException());
            string token = "123";

            var result = controller.Delete(token, 1);
            adminMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    

        [TestMethod]
        public void PutOK()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(null, adminMock.Object);

            adminMock.Setup(x => x.ModifyLodgingCapacity(It.IsAny<int>(), It.IsAny<bool>()));

            LodgingModel lodgingModel = new LodgingModel()
            {
                Id = 1,
                IsFull = true
            };
            string token = "123";

            var result = controller.Put(token, lodgingModel);
            var okResult = result as OkObjectResult;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void PutException()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(null, adminMock.Object);

            adminMock.Setup(x => x.ModifyLodgingCapacity(It.IsAny<int>(), It.IsAny<bool>()))
                .Throws(new InvalidOperationException());

            LodgingModel lodgingModel = new LodgingModel()
            {
                Id = 1,
                IsFull = true
            };
            string token = "123";

            var result = controller.Put(token, lodgingModel);
            adminMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void GetLodgingsByTP()
        {
            var lodgingLogicMock = new Mock<ILodgingLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(lodgingLogicMock.Object, null);

            lodgingLogicMock.Setup(x => x.SearchLodgings(It.IsAny<LodgingSearchModel>())).Returns(It.IsAny<IEnumerable<LodgingSearchResultModel>>());

            LodgingSearchModel model = new LodgingSearchModel();

            var result = controller.GetLodgingsByTP(model);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<LodgingSearchResultModel>;

            lodgingLogicMock.VerifyAll();
        }
    }
}
