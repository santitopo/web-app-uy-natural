using Domain;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LogicTest
{
    [TestClass]
    public class AdminLogicTest
    {
        [TestMethod]
        public void AddNewTouristicPoint()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<ITPointRepository>(MockBehavior.Strict);
            var mock3 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(mock2.Object, mock1.Object, mock3.Object, null, null, null, null, null);

            Category aCategory = new Category()
            {
                Id = 1,
                Name = "aCategory",
            };

            Region region = new Region()
            {
                Id = 1,
                Name = "Punta del Este",
            };

            TouristicPoint newTP = new TouristicPoint()
            {
                Id = 1,
                Name = "touristicPoint1",
                Description = "aDescription",
                Image = "anImage.jpg",
            };

            List<TouristicPointsCategory> tpcList = new List<TouristicPointsCategory>();
            TouristicPointsCategory tpc = new TouristicPointsCategory()
            {
                Category = aCategory,
                CategoryId = 1,
                TouristicPointId = 1,
                TouristicPoint = newTP
            };
            tpcList.Add(tpc);
            newTP.Categories = tpcList;

            mock2.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);
            mock2.Setup(x => x.Create(It.IsAny<TouristicPoint>()));
            mock2.Setup(x => x.Save());
            mock2.Setup(x => x.GetByName(It.IsAny<string>())).Returns(newTP);
            mock2.Setup(x => x.Update(It.IsAny<TouristicPoint>()));

            mock1.Setup(x => x.Get(It.IsAny<int>())).Returns(region);
            
            mock3.Setup(x => x.Get(It.IsAny<int>())).Returns(aCategory);

            int[] categories = { 1 };
            TouristicPoint ret = logic.AddTouristicPoint(newTP, 1, categories);

            Assert.AreEqual(ret, newTP);

            mock1.VerifyAll();
            mock2.VerifyAll();
            mock3.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Ya existe un punto turistico con ese nombre")]
        public void AddExistingTouristicPoint()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<ITPointRepository>(MockBehavior.Strict);
            var mock3 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(mock2.Object, mock1.Object, mock3.Object, null, null, null, null, null);

            TouristicPoint tp = new TouristicPoint() 
            { 
                Name = "touristicPoint1"
            };

            mock2.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);

            TouristicPoint ret = logic.AddTouristicPoint(tp, It.IsAny<int>(), It.IsAny<int[]>());

            mock2.VerifyAll();
        }

        [TestMethod]
        public void AddNewAdmin()
        {
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(null, null, null , null, null, userRepositoryMock.Object, null, null);

            Administrator newAdmin = new Administrator()
            {
                Id = 1,
                Name = "anAdmin",
                Mail = "anAdmin",
                Password = "anAdmin"
            };

            Administrator nullAdmin = null;

            userRepositoryMock.Setup(x => x.GetAdminByMail(It.IsAny<string>())).Returns(nullAdmin);
            userRepositoryMock.Setup(x => x.Create(It.IsAny<Administrator>()));
            userRepositoryMock.Setup(x => x.Save());

            Administrator ret = logic.AddAdmin(newAdmin);

            Assert.AreEqual(ret, newAdmin);
            userRepositoryMock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Ya existe un administrador con ese mail")]
        public void AddExistingAdmin()
        {
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(null, null, null, null, null, userRepositoryMock.Object, null, null);

            Administrator newAdmin = new Administrator()
            {
                Id = 1,
                Name = "anAdmin",
                Mail = "anAdmin",
                Password = "anAdmin"
            };

            userRepositoryMock.Setup(x => x.GetAdminByMail(It.IsAny<string>())).Returns(newAdmin);

            Administrator ret = logic.AddAdmin(newAdmin);

            userRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void AddNewLodging()
        {
            var lodgingRepositoryMock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            var tPointRepositoryMock = new Mock<ITPointRepository>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(tPointRepositoryMock.Object, null, null, lodgingRepositoryMock.Object, 
                                                null, null, null, null);

            Lodging newLodging = new Lodging()
            {
                Name = "newLodging",
                Direction = "aDirection"
            };

            TouristicPoint aTouristicPoint = new TouristicPoint()
            {
                Id = 1,
                Name = "touristicPoint1",
                Description = "aDescription",
                Image = "anImage.jpg",
            };

            Lodging expectedLodging = new Lodging()
            {
                Name = "newLodging",
                Direction = "aDirection",
                TouristicPoint = aTouristicPoint,
            };

            lodgingRepositoryMock.Setup(x => x.Exists(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            lodgingRepositoryMock.Setup(x => x.Create(It.IsAny<Lodging>()));
            lodgingRepositoryMock.Setup(x => x.Save());
            tPointRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(aTouristicPoint);

            Lodging ret = logic.AddLodging(newLodging, 1);

            Assert.AreEqual(ret, expectedLodging);
            lodgingRepositoryMock.VerifyAll();
            tPointRepositoryMock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Ya existe un hospedaje con ese nombre y direccion")]
        public void AddExistingLodging()
        {
            var lodgingRepositoryMock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            var tPointRepositoryMock = new Mock<ITPointRepository>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(tPointRepositoryMock.Object, null, null, lodgingRepositoryMock.Object,
                                                null, null, null, null);

            Lodging newLodging = new Lodging()
            {
                Name = "newLodging",
                Direction = "aDirection"
            };

            lodgingRepositoryMock.Setup(x => x.Exists(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            Lodging ret = logic.AddLodging(newLodging, 1);

            lodgingRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void RemoveAdmin()
        {
            var personRepositoryMock = new Mock<IRepository<Person>>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(null, null, null, null, personRepositoryMock.Object, null, null, null);

            Administrator newAdmin = new Administrator()
            {
                Name = "anAdmin",
                Mail = "anAdmin",
                Password = "anAdmin"
            };

            personRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(newAdmin);
            personRepositoryMock.Setup(x => x.Delete(It.IsAny<Administrator>()));
            personRepositoryMock.Setup(x => x.Save());

            logic.RemoveAdmin(It.IsAny<int>());
            personRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ModifyAdmin()
        {
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(null, null, null, null, null, userRepositoryMock.Object, null, null);

            Administrator newAdmin = new Administrator()
            {
                Name = "anAdmin",
                Mail = "anAdmin",
                Password = "anAdmin"
            };

            Administrator nullAdmin = null;

            userRepositoryMock.Setup(x => x.GetAdminByMail(It.IsAny<string>())).Returns(nullAdmin);
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Administrator>()));
            userRepositoryMock.Setup(x => x.Save());

            logic.ModifyAdmin(newAdmin);
            userRepositoryMock.VerifyAll();
        }


        [TestMethod]
        public void RemoveLodging()
        {
            var lodgingRepositoryMock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            var tPointRepositoryMock = new Mock<ITPointRepository>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(tPointRepositoryMock.Object, null, null, lodgingRepositoryMock.Object,
                                                null, null, null, null);

            Lodging newLodging = new Lodging()
            {
                Name = "newLodging",
                Direction = "aDirection"
            };

            lodgingRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(newLodging);
            lodgingRepositoryMock.Setup(x => x.Delete(It.IsAny<Lodging>()));
            lodgingRepositoryMock.Setup(x => x.Save());

            logic.RemoveLodging(1);
            lodgingRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ModifyLodgingCapacityToFull()
        {
            var lodgingRepositoryMock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(null, null, null, lodgingRepositoryMock.Object,
                                                null, null, null, null);

            Lodging aLodging = new Lodging()
            {
                Name = "newLodging",
                Direction = "aDirection",
                Capacity = false
            };

            lodgingRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(aLodging);
            lodgingRepositoryMock.Setup(x => x.Update(It.IsAny<Lodging>()));
            lodgingRepositoryMock.Setup(x => x.Save());

            logic.ModifyLodgingCapacity(1, true);
            Assert.IsTrue(aLodging.Capacity);
            lodgingRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ModifyReservationState()
        {
            var reservationRepositoryMock = new Mock<IRepository<Reservation>>(MockBehavior.Strict);
            var stateRepositoryMock = new Mock<IRepository<State>>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(null, null, null, null,  null, null, 
                                                    reservationRepositoryMock.Object, stateRepositoryMock.Object);

            Reservation aReservation = new Reservation()
            {
                Id = 1,
                Code = new Guid(),
                State = new State(),
                StateDescription = "aDescription"
            };

            State aState = new State()
            {
                Id = 1,
                Name = "Some state"
            };

            reservationRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(aReservation);
            reservationRepositoryMock.Setup(x => x.Update(It.IsAny<Reservation>()));
            reservationRepositoryMock.Setup(x => x.Save());

            stateRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(aState);

            string newDescription = "new description";

            ReservationUpdateModel reservationUpdate = new ReservationUpdateModel()
            {
                ReservationId = 1,
                StateId = 1,
                StateDescription = newDescription
            };

            logic.ModifyReservationState(reservationUpdate);

            Assert.AreEqual(aReservation.State, aState);
            Assert.AreEqual(aReservation.StateDescription, newDescription);

            reservationRepositoryMock.VerifyAll();
            stateRepositoryMock.VerifyAll();
        }

    }
}
