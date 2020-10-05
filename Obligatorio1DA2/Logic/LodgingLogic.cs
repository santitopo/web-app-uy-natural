using Domain;
using LogicInterface;
using Models;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class LodgingLogic : ILodgingLogic
    {

        private ILodgingRepository lodgingRepository;
        private IPriceCalculator priceCalculator;

        public LodgingLogic(ILodgingRepository lodgingRepository, IPriceCalculator priceCalculator)
        {
            this.lodgingRepository = lodgingRepository;
            this.priceCalculator = priceCalculator;
        }

        public IEnumerable<LodgingSearchResultModel> SearchLodgings(LodgingSearchModel search)
        {
            IEnumerable<Lodging> lst = lodgingRepository.FindByTPoint(search.TPointId).Where(x => x.Capacity);
            List<LodgingSearchResultModel> lstResults = new List<LodgingSearchResultModel>();
            foreach (Lodging l in lst) {
                LodgingSearchResultModel model = new LodgingSearchResultModel()
                {
                    Lodging = l,
                    TotalPrice = priceCalculator.CalculatePrice(search,l.Price),
                };
                lstResults.Add(model);
            }
            return lstResults;
        }
    }
}
