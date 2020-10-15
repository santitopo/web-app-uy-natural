using Domain;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicTest
{
    [TestClass]
    public class SessionLogicTest
    {
        [TestMethod]
        public void NewLogIn()
        {
            var mock1 = new Mock<IRepository<UserSession>>(MockBehavior.Strict);
            var mock2 = new Mock<IAdminRepository>(MockBehavior.Strict);
            SessionLogic logic = new SessionLogic(mock2.Object, mock1.Object);

            Administrator admin = new Administrator()
            {
                Id = 1,
                Name = "admin",
                Surname = "admin",
                Mail = "admin",
                Password = "admin"
            };

            mock2.Setup(x => x.GetAdminByMailAndPassword("admin", "admin")).Returns(admin);

            List<UserSession> emptyUserSessions = new List<UserSession>();

            mock1.Setup(x => x.GetAll(It.IsAny<string[]>())).Returns(emptyUserSessions);
            mock1.Setup(x => x.Create(It.IsAny<UserSession>()));
            mock1.Setup(x => x.Save());

            var token = logic.LogIn("admin", "admin");
            mock2.VerifyAll();
            mock1.VerifyAll();

            Assert.IsInstanceOfType(token, typeof(string));
        }

        [TestMethod]
        public void AlreadyLoggedIn()
        {
            var mock1 = new Mock<IRepository<UserSession>>(MockBehavior.Strict);
            var mock2 = new Mock<IAdminRepository>(MockBehavior.Strict);
            SessionLogic logic = new SessionLogic(mock2.Object, mock1.Object);

            Administrator admin = new Administrator()
            {
                Id = 1,
                Name = "admin",
                Surname = "admin",
                Mail = "admin",
                Password = "admin"
            };

            UserSession userSession = new UserSession()
            {
                Id = 1,
                ConnectedAt = DateTime.Now,
                Token = "8b10f257-3b16-4461-984f-6c7407e4008f",
                User = admin
            };

            string expectedToken = "8b10f257-3b16-4461-984f-6c7407e4008f";

            mock2.Setup(x => x.GetAdminByMailAndPassword("admin", "admin")).Returns(admin);

            List<UserSession> userSessions = new List<UserSession>();
            userSessions.Add(userSession);

            mock1.Setup(x => x.GetAll(It.IsAny<string[]>())).Returns(userSessions);
            var token = logic.LogIn("admin", "admin");

            mock2.VerifyAll();
            mock1.VerifyAll();

            Assert.AreEqual(expectedToken, token);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "User or password incorrect")]
        public void AdminNotExists()
        {
            var mock1 = new Mock<IRepository<UserSession>>(MockBehavior.Strict);
            var mock2 = new Mock<IAdminRepository>(MockBehavior.Strict);
            SessionLogic logic = new SessionLogic(mock2.Object, mock1.Object);

            Administrator admin = null;

            mock2.Setup(x => x.GetAdminByMailAndPassword("admin2", "admin2")).Returns(admin);

            var result = logic.LogIn("admin2", "admin2");
            mock2.VerifyAll();
        }
        
        [TestMethod]
        public void LogOutCorrect()
        {
            var mock1 = new Mock<IRepository<UserSession>>(MockBehavior.Strict);
            var mock2 = new Mock<IAdminRepository>(MockBehavior.Strict);
            SessionLogic logic = new SessionLogic(mock2.Object, mock1.Object);

            UserSession userSession = new UserSession()
            {
                Id = 1,
                ConnectedAt = DateTime.Now,
                Token = "8b10f257-3b16-4461-984f-6c7407e4008f",
                User = new Administrator()
            };

            List<UserSession> userSessions = new List<UserSession>();
            userSessions.Add(userSession);

            mock1.Setup(x => x.GetAll(It.IsAny<string[]>())).Returns(userSessions);
            mock1.Setup(x => x.Delete(It.IsAny<UserSession>()));
            mock1.Setup(x => x.Save());

            logic.LogOut("8b10f257-3b16-4461-984f-6c7407e4008f");

            mock1.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Token doesn't exist")]
        public void LogoutTokenDoesNotExists()
        {
            var mock1 = new Mock<IRepository<UserSession>>(MockBehavior.Strict);
            var mock2 = new Mock<IAdminRepository>(MockBehavior.Strict);
            SessionLogic logic = new SessionLogic(mock2.Object, mock1.Object);

            List<UserSession> userSessions = new List<UserSession>();

            mock1.Setup(x => x.GetAll(It.IsAny<string[]>())).Returns(userSessions);

            logic.LogOut("8b10f257-3b16-4461-984f-6c7407e4008f");

            mock1.VerifyAll();
        }

        [TestMethod]
        public void IsLogued()
        {
            var mock1 = new Mock<IRepository<UserSession>>(MockBehavior.Strict);
            var mock2 = new Mock<IAdminRepository>(MockBehavior.Strict);
            SessionLogic logic = new SessionLogic(mock2.Object, mock1.Object);

            Administrator admin = new Administrator()
            {
                Id = 1,
                Name = "admin",
                Surname = "admin",
                Mail = "admin",
                Password = "admin"
            };
            UserSession userSession = new UserSession()
            {
                Id = 1,
                ConnectedAt = DateTime.Now,
                Token = "8b10f257-3b16-4461-984f-6c7407e4008f",
                User = admin
            };
            string Token = "8b10f257-3b16-4461-984f-6c7407e4008f";
            List<UserSession> userSessions = new List<UserSession>();
            userSessions.Add(userSession);

            string[] param = { };
            mock1.Setup(x => x.GetAll(param)).Returns(userSessions);

            var res = logic.IsLogued(Token);
            Assert.IsTrue(res);

            mock1.VerifyAll();
        }

    }
}
