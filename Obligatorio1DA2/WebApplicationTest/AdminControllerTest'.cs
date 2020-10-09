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
    public class AdminControllerTest
    {
        [TestMethod]
        public void PostOk()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            AdminController controller = new AdminController(adminMock.Object);


            Administrator admin = new Administrator()
            {
                Mail = "admin",
                Name = "admin",
                Password = "admin",
            };

            adminMock.Setup(x => x.AddAdmin(It.IsAny<Administrator>())).Returns(admin);
            string token = "123";

            var result = controller.Post(token, admin);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as Administrator;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void InvalidPost()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            AdminController controller = new AdminController(adminMock.Object);

            Administrator nullAdmin = null;

            adminMock.Setup(x => x.AddAdmin(It.IsAny<Administrator>())).
                Throws(new InvalidOperationException("Ya existe un administrador con ese mail"));
            string token = "123";

            var result = controller.Post(token, It.IsAny<Administrator>());
            var response = result as ObjectResult;
            Assert.AreEqual(400, response.StatusCode);

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteOK()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            AdminController controller = new AdminController(adminMock.Object);

            Administrator admin = new Administrator()
            {
                Id = 1,
                Mail = "admin",
                Name = "admin",
                Password = "admin",
            };

            adminMock.Setup(x => x.RemoveAdmin(It.IsAny<int>()));
            string token = "123";

            var result = controller.Delete(token, 1);
            var okResult = result as OkObjectResult;
            
            adminMock.VerifyAll();
        }
        [TestMethod]
        public void PutOk()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            AdminController controller = new AdminController(adminMock.Object);

            Administrator admin = new Administrator()
            {
                Mail = "admin",
                Name = "admin",
                Password = "admin",
            };

            adminMock.Setup(x => x.ModifyAdmin(admin));
            string token = "123";

            var result = controller.Put(token, admin);
            var okResult = result as OkObjectResult;

            adminMock.VerifyAll();
        }


    }
}
