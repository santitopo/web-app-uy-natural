using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Controllers;
using Models;

namespace WebApplicationTest
{
    public class LodgingControllerTest
    {

        [TestMethod]
        public void GetLodgingsByTP()
        {
            var lodgingLogicMock = new Mock<ILodgingLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(lodgingLogicMock.Object);

            lodgingLogicMock.Setup(x => x.SearchLodgings(It.IsAny<LodgingSearchModel>())).Returns(It.IsAny<IEnumerable<LodgingSearchResultModel>>());

            LodgingSearchModel model = new LodgingSearchModel();

            var result = controller.GetLodgingsByTP(model);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<LodgingSearchResultModel>;

            lodgingLogicMock.VerifyAll();
        }
    }
}
