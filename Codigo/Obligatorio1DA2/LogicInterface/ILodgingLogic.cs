using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface ILodgingLogic
    {
        Review AddReview(Guid reservationCode, string description, int score);

        IEnumerable<LodgingSearchResultModel> SearchLodgings(LodgingSearchModel Search);

        IEnumerable<Lodging> SearchBySimilarNameandTpoint(string lodgingName, int tpointId);
    }
}
