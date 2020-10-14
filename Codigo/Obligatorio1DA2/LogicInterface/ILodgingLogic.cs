using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface ILodgingLogic
    {
        //PRE:
        //POS: Returns a list of Lodgings with total prices for the period
        IEnumerable<LodgingSearchResultModel> SearchLodgings(LodgingSearchModel Search);
    }
}
