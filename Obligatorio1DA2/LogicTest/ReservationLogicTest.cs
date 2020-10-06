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
    public class ReservationLogicTest
    {
        [TestMethod]
        public void GetAllReservations()
        {
            var mock1 = new Mock<IRepository<Reservation>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<State>>(MockBehavior.Strict);
            ReservationLogic logic = new ReservationLogic(mock1.Object, mock2.Object);

            string[] param = { };
            mock1.Setup(x => x.GetAll(param)).Returns(It.IsAny<IEnumerable<Reservation>>);

            IEnumerable<Reservation> ret = logic.GetAllReservations();
            mock1.VerifyAll();
        }

        [TestMethod]
        public void GetAllStates()
        {
            var mock1 = new Mock<IRepository<Reservation>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<State>>(MockBehavior.Strict);
            ReservationLogic logic = new ReservationLogic(mock1.Object, mock2.Object);

            string[] param = { };
            mock2.Setup(x => x.GetAll(param)).Returns(It.IsAny<IEnumerable<State>>);

            IEnumerable<State> ret = logic.GetAllStates();
            mock1.VerifyAll();
        }
    }
}
