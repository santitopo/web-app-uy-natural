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
    public class PersonControllerTest
    {
        [TestMethod]
        public void PostOk()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            PersonController controller = new PersonController(adminMock.Object);


            Administrator admin = new Administrator()
            {
                Mail = "admin",
                Name = "admin",
                Password = "admin",
            };

            adminMock.Setup(x => x.AddAdmin(It.IsAny<Administrator>())).Returns(admin);

            var result = controller.Post(admin);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as Administrator;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void InvalidPost()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            PersonController controller = new PersonController(adminMock.Object);

            Administrator nullAdmin = null;

            adminMock.Setup(x => x.AddAdmin(It.IsAny<Administrator>())).Returns(nullAdmin);

            var result = controller.Post(It.IsAny<Administrator>());
            var response = result as ObjectResult;
            Assert.AreEqual(409, response.StatusCode);
            adminMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteOK()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            PersonController controller = new PersonController(adminMock.Object);

            Administrator admin = new Administrator()
            {
                Id = 1,
                Mail = "admin",
                Name = "admin",
                Password = "admin",
            };

            adminMock.Setup(x => x.RemoveAdmin(It.IsAny<int>()));

            var result = controller.Delete(1);
            var okResult = result as OkObjectResult;
            
            adminMock.VerifyAll();
        }
        [TestMethod]
        public void PutOk()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            PersonController controller = new PersonController(adminMock.Object);

            Administrator admin = new Administrator()
            {
                Mail = "admin",
                Name = "admin",
                Password = "admin",
            };

            adminMock.Setup(x => x.ModifyAdmin(admin));

            var result = controller.Put(admin);
            var okResult = result as OkObjectResult;

            adminMock.VerifyAll();
        }


    }
}
