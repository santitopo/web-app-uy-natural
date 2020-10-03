using System;
using System.Collections.Generic;
using System.Text;
using LogicInterface;
using Models;

namespace Logic
{
    public class PriceCalculator : IPriceCalculator
    {
        public double CalculatePrice(LodgingSearchModel search, double pricePerNight)
        {
            double price = 0;
            DateTime checkin = DateTime.ParseExact(search.Checkin, "ddMMyyyy", null) ;
            DateTime checkout = DateTime.ParseExact(search.Checkout, "ddMMyyyy", null);
            int days = checkout.Subtract(checkin).Days;
            price += search.AdultsNum * days * pricePerNight;
            price += Convert.ToInt32(search.ChildsNum * 0.5 * days * pricePerNight);
            price += Convert.ToInt32(search.BabiesNum * 0.25 * days * pricePerNight);
            return price;
        }
    }
}
