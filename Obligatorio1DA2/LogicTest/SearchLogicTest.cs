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
        public void GetAllRegionsOk()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var mock3 = new Mock<IRepository<TouristicPoint>>(MockBehavior.Strict);
            SearchLogic logic = new SearchLogic(mock1.Object, mock2.Object, mock3.Object);
            mock1.Setup(x => x.GetAll()).Returns(It.IsAny<IEnumerable<Region>>);

            IEnumerable<Region> ret = logic.GetAllRegions();

            mock1.VerifyAll();
        }

        [TestMethod]
        public void GetTPointsByRegionOk()
        {
            var mock1 = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var mock3 = new Mock<IRepository<TouristicPoint>>(MockBehavior.Strict);
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
                TouristicPointsCategory = null,
            };
            List<TouristicPoint> lst = new List<TouristicPoint>();
            lst.Add(tp);

            mock1.Setup(x => x.Get(1)).Returns(region);
            mock3.Setup(x => x.GetAll()).Returns(lst);

            IEnumerable<TouristicPoint> ret = logic.GetTPointsByRegion(1);

            mock1.VerifyAll();
            mock3.VerifyAll();

            
            CollectionAssert.AreEqual(ret.ToList(), lst);
                }

    }



}
