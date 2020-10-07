using Domain;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersistenceInterface;
using System.Collections.Generic;
using System.Linq;

namespace LogicTest
{
    [TestClass]
    public class SearchLogicTest
    {
        [TestMethod]
        public void GetAllRegions()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var mock3 = new Mock<ITPointRepository>(MockBehavior.Strict);
            SearchLogic logic = new SearchLogic(mock1.Object, mock2.Object, mock3.Object);
            string[] strlst = {};
            mock1.Setup(x => x.GetAll(strlst)).Returns(It.IsAny<IEnumerable<Region>>);

            IEnumerable<Region> ret = logic.GetAllRegions();

            mock1.VerifyAll();
        }

        [TestMethod]
        public void GetTPointsByRegion()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var mock3 = new Mock<ITPointRepository>(MockBehavior.Strict);
            SearchLogic logic = new SearchLogic(mock1.Object, mock2.Object, mock3.Object);

            Region region = new Region()
            {
                Id = 1,
                Name = "Punta del Este",
            };

            TouristicPoint tp = new TouristicPoint()
            {
                Description = "Hotel Barradas",
                Image = "hotel.png",
                Name = "Barradas",
                Region = region,
                Categories = null,
            };
            List<TouristicPoint> expectedLst = new List<TouristicPoint>();
            expectedLst.Add(tp);

            mock3.Setup(x => x.FindByRegion(1)).Returns(expectedLst);
            mock1.Setup(x => x.Get(It.IsAny<int>())).Returns(region);


            IEnumerable<TouristicPoint> ret = logic.GetTPointsByRegion(1);

            mock3.VerifyAll();
            CollectionAssert.AreEqual(ret.ToList(), expectedLst);
        }

        [TestMethod]
        public void GetAllTPoints()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var mock3 = new Mock<ITPointRepository>(MockBehavior.Strict);
            SearchLogic logic = new SearchLogic(mock1.Object, mock2.Object, mock3.Object);
            string[] strlst = {"Region"};
            mock3.Setup(x => x.GetAll(strlst)).Returns(It.IsAny<IEnumerable<TouristicPoint>>);

            IEnumerable<TouristicPoint> ret = logic.GetAllTPoints();

            mock3.VerifyAll();
        }

        [TestMethod]
        public void GetAllCategories()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var mock3 = new Mock<ITPointRepository>(MockBehavior.Strict);
            SearchLogic logic = new SearchLogic(mock1.Object, mock2.Object, mock3.Object);
            string[] strlst = { };
            mock2.Setup(x => x.GetAll(strlst)).Returns(It.IsAny<IEnumerable<Category>>);

            IEnumerable<Category> ret = logic.GetAllCategories();

            mock2.VerifyAll();
        }

        [TestMethod]
        public void FindByRegionCat()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var mock3 = new Mock<ITPointRepository>(MockBehavior.Strict);
            SearchLogic logic = new SearchLogic(mock1.Object, mock2.Object, mock3.Object);

            Region region = new Region() { };
            int[] categories= { };

            mock1.Setup(x => x.Get(It.IsAny<int>())).Returns(region);
            mock3.Setup(x => x.FindByRegionCat(1,categories)).Returns(It.IsAny<IEnumerable<TouristicPoint>>);

            IEnumerable<TouristicPoint> ret = logic.FindByRegionCat(1,categories);

            mock2.VerifyAll();
        }
    }



}
