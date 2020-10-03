using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace LogicInterface
{
    public interface IPriceCalculator
    {

        double CalculatePrice(LodgingSearchModel search, double pricePerNight);  

    }
}
