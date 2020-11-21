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
        private IRepository<Review> reviewRepository;
        private IReservationRepository reservationRepository;
        private IPriceCalculator priceCalculator;

        public LodgingLogic(ILodgingRepository lodgingRepository, IPriceCalculator priceCalculator, 
            IReservationRepository reservationRepository, IRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
            this.lodgingRepository = lodgingRepository;
            this.reservationRepository = reservationRepository;
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

        public Review AddReview(Guid reservationCode, string description, int score)
        {
            Reservation reservation = reservationRepository.FindByCode(reservationCode);
            if (reservation != null)
            {
                Review newReview = new Review
                {
                    Client = reservation.Client,
                    Description = description,
                    Score = score,
                    Reservation = reservation
                };
                reviewRepository.Create(newReview);
                reviewRepository.Save();

                UpdateScore(reservation.Lodging, score);

                return newReview;
            }
            else
            {
                throw new InvalidOperationException("El codigo de reserva no existe");
            }
        }

        private void UpdateScore(Lodging lodging, int score)
        {
            int totalReviews = 0;
            int totalScore = 0;
            string [] param = { "Reservation.Lodging" , "Client" };

            List<Review> reviews = reviewRepository.GetAll(param).ToList();
            foreach(Review review in reviews)
            {
                if (review.Reservation.Lodging.Equals(lodging))
                {
                    totalReviews++;
                    totalScore += review.Score;
                }
            }
            lodging.Score = totalScore / totalReviews;

            lodgingRepository.Update(lodging);
            lodgingRepository.Save();
        }
    }
}
