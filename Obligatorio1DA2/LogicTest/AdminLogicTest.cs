using Domain;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            AdminLogic logic = new AdminLogic(mock2.Object, mock1.Object, mock3.Object);

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
        public void AddExistingTouristicPoint()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<ITPointRepository>(MockBehavior.Strict);
            var mock3 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            AdminLogic logic = new AdminLogic(mock2.Object, mock1.Object, mock3.Object);

            TouristicPoint tp = new TouristicPoint() 
            { 
                Name = "touristicPoint1"
            };

            mock2.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);

            TouristicPoint ret = logic.AddTouristicPoint(tp, It.IsAny<int>(), It.IsAny<int[]>());

            Assert.IsNull(ret);
            mock2.VerifyAll();
        }

    }
}
