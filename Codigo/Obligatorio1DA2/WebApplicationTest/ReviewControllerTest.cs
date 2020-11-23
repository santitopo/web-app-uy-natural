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
    public class ReviewControllerTest
    {
        [TestMethod]
        public void PostOk()
        {
            var mock = new Mock<ILodgingLogic>(MockBehavior.Strict);

            ReviewController controller = new ReviewController(mock.Object, null);

            ReviewModel reviewModel = new ReviewModel()
            {
                Description = "aReview"
            };

            Review aReview = new Review()
            {
                Description = "aReview"
            };

            mock.Setup(x => x.AddReview(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<int>())).Returns(aReview);

            var result = controller.Post(reviewModel);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as Review;

            mock.VerifyAll();
        }

        [TestMethod]
        public void PostError()
        {
            var mock = new Mock<ILodgingLogic>(MockBehavior.Strict);

            ReviewController controller = new ReviewController(mock.Object, null);

            ReviewModel reviewModel = new ReviewModel()
            {
                Description = "aReview"
            };

            Review aReview = new Review()
            {
                Description = "aReview"
            };

            mock.Setup(x => x.AddReview(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<int>())).
                Throws(new InvalidOperationException("El codigo de reserva no existe"));

            var result = controller.Post(reviewModel);
            var response = result as ObjectResult;
            Assert.AreEqual(400, response.StatusCode);

            mock.VerifyAll();
        }

        [TestMethod]
        public void GetReviewByReservationCode()
        {
            var mock = new Mock<IReservationLogic>(MockBehavior.Strict);

            ReviewController controller = new ReviewController(null, mock.Object);

            mock.Setup(x => x.ReviewExistsbyGuid(It.IsAny<string>())).Returns(It.IsAny<bool>());
                
            var result = controller.GetReviewByReservationCode("1234");
            var response = result as ObjectResult;
            Assert.AreEqual(200, response.StatusCode);

            mock.VerifyAll();
        }

        [TestMethod]
        public void GetReviewByReservationCodeError()
        {
            var mock = new Mock<IReservationLogic>(MockBehavior.Strict);

            ReviewController controller = new ReviewController(null, mock.Object);

            mock.Setup(x => x.ReviewExistsbyGuid(It.IsAny<string>())).Throws(new InvalidOperationException());

            var result = controller.GetReviewByReservationCode("1234");
            var response = result as ObjectResult;
            Assert.AreEqual(400, response.StatusCode);

            mock.VerifyAll();
        }


    }
}
