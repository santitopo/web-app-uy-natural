using Domain;
using Filters;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WebApplication.Controllers;


namespace WebApplicationTest
{
    [TestClass]
    public class TPointControllerTest
    {
        [TestMethod]
        public void GetAllTPoints()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            var otherMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            TPointController controller = new TPointController(logicMock.Object, otherMock.Object);

            List<TouristicPointOutModel> ret = new List<TouristicPointOutModel>();
            ret.Add(new TouristicPointOutModel() { });

            logicMock.Setup(x => x.GetAllTPoints()).Returns(ret);

            var result = controller.GetAllTPoints();
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<TouristicPoint>;

            logicMock.VerifyAll();
        }


        [TestMethod]
        public void GetTPointsByRegion()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            var otherMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            TPointController controller = new TPointController(logicMock.Object, otherMock.Object);

            List<TouristicPoint> ret = new List<TouristicPoint>();
            ret.Add(new TouristicPoint() { });

            logicMock.Setup(x => x.GetTPointsByRegion(1)).Returns(ret);

            var result = controller.GetTPointsByRegionCat(1, null);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<TouristicPoint>;

            logicMock.VerifyAll();
        }


        [TestMethod]
        public void GetTPointsByRegionCat()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            var otherMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            TPointController controller = new TPointController(logicMock.Object, otherMock.Object);

            List<TouristicPoint> ret = new List<TouristicPoint>();
            ret.Add(new TouristicPoint() { });

            int[] numbers = { 1, 3 };
            logicMock.Setup(x => x.FindByRegionCat(1, numbers)).Returns(ret);

            var result = controller.GetTPointsByRegionCat(1, numbers);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<TouristicPoint>;

            logicMock.VerifyAll();
        }

        [TestMethod]
        public void GetTPointsByRegionCatException()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            TPointController controller = new TPointController(logicMock.Object, null);

            logicMock.Setup(x => x.GetTPointsByRegion(1)).Throws(new InvalidOperationException("La region no existe"));

            var result = controller.GetTPointsByRegionCat(1, null);

            logicMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void GetTPointsByRegionCatFail()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            TPointController controller = new TPointController(logicMock.Object, null);

            List<TouristicPoint> ret = null;
            logicMock.Setup(x => x.GetTPointsByRegion(1)).Returns(ret);

            var result = controller.GetTPointsByRegionCat(1, null);

            logicMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void PostOk()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            TPointController controller = new TPointController(logicMock.Object, adminMock.Object);

            int[] categories = { 1, 2, 3 };

            TouristicPointInsertModel tpModel = new TouristicPointInsertModel()
            {
                Categories = categories,
                RegionId = 1,
            };

            TouristicPoint tp = new TouristicPoint();

            adminMock.Setup(x => x.AddTouristicPoint(It.IsAny<TouristicPoint>(), It.IsAny<int>(), It.IsAny<int[]>()))
                .Returns(tp);
            string token = "123";

            var result = controller.Post(token, tpModel);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as TouristicPoint;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void InvalidPost()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            TPointController controller = new TPointController(logicMock.Object, adminMock.Object);

            int[] categories = { 1, 2, 3 };

            TouristicPointInsertModel tpModel = new TouristicPointInsertModel()
            {
                Categories = categories,
                RegionId = 1,
            };

            TouristicPoint tp = null;

            adminMock.Setup(x => x.AddTouristicPoint(It.IsAny<TouristicPoint>(), It.IsAny<int>(), It.IsAny<int[]>()))
                .Throws(new InvalidOperationException("Ya existe un punto turistico con ese nombre"));
            string token = "123";

            var result = controller.Post(token, tpModel);
            var response = result as ObjectResult;

            Assert.AreEqual(400, response.StatusCode);
            adminMock.VerifyAll();
        }
    }
}
