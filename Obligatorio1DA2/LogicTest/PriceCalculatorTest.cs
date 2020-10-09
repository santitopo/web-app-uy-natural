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
    public class PriceCalculatorTest
    {
        [TestMethod]
        public void CalculatePrice()
        {
            PriceCalculator calculator = new PriceCalculator();
            LodgingSearchModel search = new LodgingSearchModel()
            {
                AdultsNum = 2,
                ChildsNum = 1,
                BabiesNum = 1,
                Checkin = "12102019",
                Checkout = "13102019",
                TPointId = 0
            };
            double price = calculator.CalculatePrice(search, 20);

            Assert.AreEqual(55, price);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Error en el formato de fechas.Formato esperado 'ddMMyyyy'")]
        public void BadCalculatePrice()
        {
            PriceCalculator calculator = new PriceCalculator();
            LodgingSearchModel search = new LodgingSearchModel()
            {
                AdultsNum = 2,
                ChildsNum = 1,
                BabiesNum = 1,
                Checkin = "12/10/2019",
                Checkout = "13/10/2019",
                TPointId = 0
            };
            double price = calculator.CalculatePrice(search, 20);


        }

    }
}
