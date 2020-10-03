using Domain;
using Logic;
using LogicInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersistenceInterface;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace LogicTest
{
    [TestClass]
    public class LodgingLogicTest
    {
        [TestMethod]
        public void SearchLodgings()
        {
            var mock1 = new Mock<ILodgingRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IPriceCalculator>(MockBehavior.Strict);
            LodgingLogic logic = new LodgingLogic(mock1.Object, mock2.Object);

            List<Lodging> lst = new List<Lodging>();
            TouristicPoint tpoint = new TouristicPoint()
            {
                Id = 2,
            };
            Lodging lod1 = new Lodging()
            {
                Available = true,
                Id = 1,
                IsDeleted = false,
                TPoint = tpoint,
                Price = 20.0,
            };
            Lodging lod2 = new Lodging()
            {
                Available = false,
                Id = 2,
                IsDeleted = false,
                TPoint = tpoint,
                Price = 30.0,
            };
            lst.Add(lod1);
            lst.Add(lod2);

            LodgingSearchModel search = new LodgingSearchModel()
            {
                TPointId = 2,
            };
            mock1.Setup(x => x.FindByTPoint(search.TPointId)).Returns(lst);
            mock2.Setup(x => x.CalculatePrice(It.IsAny<LodgingSearchModel>(), 20.0)).Returns(40.0);


            IEnumerable<LodgingSearchResultModel> ret = logic.SearchLodgings(search);

            mock1.VerifyAll();
            Assert.AreEqual(ret.Count(), 1);
            Assert.AreEqual(ret.ElementAt(0).TotalPrice,40.0);
        }

    }
}
