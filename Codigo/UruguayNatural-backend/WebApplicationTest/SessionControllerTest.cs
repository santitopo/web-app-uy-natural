using Filters;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
    public class SessionControllerTest
    {
        [TestMethod]
        public void LoginOk()
        {
            var logicMock = new Mock<ISessionLogic>(MockBehavior.Strict);
            SessionController controller = new SessionController(logicMock.Object);
            LoginModel loginModel = new LoginModel()
            {
                Mail = "user1@hotmail.com",
                Password = "user",
            };

            string token = "8b10f257-3b16-4461-984f-6c7407e4008f";

            logicMock.Setup(x => x.LogIn("user1@hotmail.com", "user")).Returns(token);

            var result = controller.Login(loginModel);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as string;

            Assert.AreEqual(value, token);
            logicMock.VerifyAll();
        }

        [TestMethod]
        public void LoginOkException()
        {
            var logicMock = new Mock<ISessionLogic>(MockBehavior.Strict);
            SessionController controller = new SessionController(logicMock.Object);
            LoginModel loginModel = new LoginModel()
            {
                Mail = "user1@hotmail.com",
                Password = "user",
            };

            logicMock.Setup(x => x.LogIn("user1@hotmail.com", "user")).Throws(new InvalidOperationException());

            var result = controller.Login(loginModel);

            logicMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void LogoutOk()
        {
            var logicMock = new Mock<ISessionLogic>(MockBehavior.Strict);
            SessionController controller = new SessionController(logicMock.Object);
            LoginModel loginModel = new LoginModel()
            {
                Mail = "user1@hotmail.com",
                Password = "user",
            };

            string token = "8b10f257-3b16-4461-984f-6c7407e4008f";

            logicMock.Setup(x => x.LogOut(token));

            var result = controller.Logout(token);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [TestMethod]
        public void LogoutException()
        {
            var logicMock = new Mock<ISessionLogic>(MockBehavior.Strict);
            SessionController controller = new SessionController(logicMock.Object);
            string token = "8b10f257-3b16-4461-984f-6c7407e4008f";

            logicMock.Setup(x => x.LogOut(token)).Throws(new InvalidOperationException());

            var result = controller.Logout(token);
            logicMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void SessionExists()
        {
            var logicMock = new Mock<ISessionLogic>(MockBehavior.Strict);
            SessionController controller = new SessionController(logicMock.Object);
            
            string token = "8b10f257-3b16-4461-984f-6c7407e4008f";

            logicMock.Setup(x => x.IsLogued(token)).Returns(true);

            var result = controller.Exists(token);
            var okResult = result as OkObjectResult;
            var value = (bool) okResult.Value;

            Assert.AreEqual(value, true);
            logicMock.VerifyAll();
        }

    }
}
