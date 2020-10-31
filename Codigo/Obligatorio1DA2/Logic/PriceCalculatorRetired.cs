using LogicInterface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PriceCalculatorRetired : IPriceCalculator
    {
        public double CalculatePrice(LodgingSearchModel search, double pricePerNight)
        {
            double price = 0;
            DateTime checkin;
            DateTime checkout;
            try
            {
                checkin = DateTime.ParseExact(search.Checkin, "ddMMyyyy", null);
                checkout = DateTime.ParseExact(search.Checkout, "ddMMyyyy", null);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Error en el formato de fechas. Formato esperado 'ddMMyyyy'");
            }
            int days = checkout.Subtract(checkin).Days;
            //Retired with discount
            price += (search.RetiredNum / 2 * 0.7 * days * pricePerNight);
            //Retired without discount
            price += ((search.RetiredNum - (search.RetiredNum / 2)) * days * pricePerNight);
            price += (search.AdultsNum * days * pricePerNight);
            price += (search.ChildsNum * 0.5 * days * pricePerNight);
            price += (search.BabiesNum * 0.25 * days * pricePerNight);
            return price;
        }

        public double CalculatePrice(ReservationModel search, double pricePerNight)
        {
            double price = 0;
            DateTime checkin;
            DateTime checkout;
            try
            {
                checkin = DateTime.ParseExact(search.Checkin, "ddMMyyyy", null);
                checkout = DateTime.ParseExact(search.Checkout, "ddMMyyyy", null);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Error en el formato de fechas. Formato esperado 'ddMMyyyy'");
            }
            int days = checkout.Subtract(checkin).Days;
            //Retired with discount
            price += (search.RetiredNum / 2 * 0.7 * days * pricePerNight);
            //Retired without discount
            price += ((search.RetiredNum - (search.RetiredNum / 2)) * days * pricePerNight);
            price += (search.AdultsNum * days * pricePerNight);
            price += (search.ChildsNum * 0.5 * days * pricePerNight);
            price += (search.BabiesNum * 0.25 * days * pricePerNight);
            return price;
        }
    }
}
