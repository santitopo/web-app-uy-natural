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
    public class PriceCalculatorRetiredTest
    {
        [TestMethod]
        public void CalculatePrice()
        {
            PriceCalculatorRetired calculator = new PriceCalculatorRetired();
            LodgingSearchModel search = new LodgingSearchModel()
            {
                RetiredNum = 2,
                Checkin = "12102019",
                Checkout = "13102019",
                TPointId = 0
            };
            double price = calculator.CalculatePrice(search, 100);

            Assert.AreEqual(170+0.0, price);

        }

        [TestMethod]
        public void CalculatePriceOddRetiredNumber()
        {
            PriceCalculatorRetired calculator = new PriceCalculatorRetired();
            LodgingSearchModel search = new LodgingSearchModel()
            {
                RetiredNum = 3,
                Checkin = "12102019",
                Checkout = "13102019",
                TPointId = 0
            };
            double price = calculator.CalculatePrice(search, 100);

            Assert.AreEqual(270 + 0.0, price);

        }

        [TestMethod]
        public void CalculatePriceOddRetiredNumber2()
        {
            PriceCalculatorRetired calculator = new PriceCalculatorRetired();
            LodgingSearchModel search = new LodgingSearchModel()
            {
                RetiredNum = 5,
                Checkin = "12102019",
                Checkout = "13102019",
                TPointId = 0
            };
            double price = calculator.CalculatePrice(search, 100);

            Assert.AreEqual(440 + 0.0, price);

        }

        [TestMethod]
        public void CalculatePriceEvenRetiredNumber()
        {
            PriceCalculatorRetired calculator = new PriceCalculatorRetired();
            LodgingSearchModel search = new LodgingSearchModel()
            {
                RetiredNum = 4,
                Checkin = "12102019",
                Checkout = "13102019",
                TPointId = 0
            };
            double price = calculator.CalculatePrice(search, 100);

            Assert.AreEqual(340 + 0.0, price);

        }

        [TestMethod]
        public void CalculatePriceAllFamily()
        {
            PriceCalculatorRetired calculator = new PriceCalculatorRetired();
            LodgingSearchModel search = new LodgingSearchModel()
            {
                RetiredNum = 2,
                AdultsNum = 1,
                BabiesNum = 1,
                ChildsNum = 1,
                Checkin = "12102019",
                Checkout = "13102019",
                TPointId = 0
            };
            double price = calculator.CalculatePrice(search, 100);

            Assert.AreEqual(345 + 0.0, price);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Error en el formato de fechas.Formato esperado 'ddMMyyyy'")]
        public void BadCalculatePrice()
        {
            PriceCalculatorRetired calculator = new PriceCalculatorRetired();
            LodgingSearchModel search = new LodgingSearchModel()
            {
                RetiredNum =1,
                AdultsNum = 2,
                ChildsNum = 1,
                BabiesNum = 1,
                Checkin = "12/10/2019",
                Checkout = "13/10/2019",
                TPointId = 0
            };
            double price = calculator.CalculatePrice(search, 20);


        }

        [TestMethod]
        public void CalculatePriceReservation()
        {
            PriceCalculatorRetired calculator = new PriceCalculatorRetired();
            ReservationModel reservation = new ReservationModel()
            {
                RetiredNum = 2,
                Checkin = "12102019",
                Checkout = "13102019"
            };
            double price = calculator.CalculatePrice(reservation, 100);

            Assert.AreEqual(170 + 0.0, price);

        }



        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Error en el formato de fechas.Formato esperado 'ddMMyyyy'")]
        public void BadCalculatePriceReservation()
        {
            PriceCalculatorRetired calculator = new PriceCalculatorRetired();
            ReservationModel reservation = new ReservationModel()
            {
                Checkin = "12/10/2019",
                Checkout = "13/10/2019"
            };
            double price = calculator.CalculatePrice(reservation, 20);


        }

    }
}
