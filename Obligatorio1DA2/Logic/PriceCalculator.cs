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
            int days = search.Checkout.Subtract(search.Checkin).Days;
            price += search.AdultsNum * days * pricePerNight;
            price += Convert.ToInt32(search.ChildsNum * 0.5 * days * pricePerNight);
            price += Convert.ToInt32(search.BabiesNum * 0.25 * days * pricePerNight);
            return price;
        }
    }
}
