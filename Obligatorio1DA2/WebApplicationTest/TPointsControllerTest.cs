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
    public class TPointsControllerTest
    {
        [TestMethod]
        public void GetAllTPoints()
        {
            var logicMock = new Mock<ISearchLogic>(MockBehavior.Strict);
            TPointsController controller = new TPointsController(logicMock.Object);

            List<TouristicPoint> ret = new List<TouristicPoint>();
            ret.Add(new TouristicPoint() { });

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
            TPointsController controller = new TPointsController(logicMock.Object);

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
            TPointsController controller = new TPointsController(logicMock.Object);

            List<TouristicPoint> ret = new List<TouristicPoint>();
            ret.Add(new TouristicPoint() { });

            int[] numbers = { 1, 3 };
            logicMock.Setup(x => x.FindByRegionCat(1,numbers)).Returns(ret);

            var result = controller.GetTPointsByRegionCat(1,numbers);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<TouristicPoint>;

            logicMock.VerifyAll();
        }
    }
}
