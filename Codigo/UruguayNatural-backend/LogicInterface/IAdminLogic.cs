using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface IAdminLogic
    {
        IEnumerable<Administrator> GetAdmins();

        TouristicPoint AddTouristicPoint(TouristicPoint aTouristicPoint, int regionId, int [] categories);

        Lodging AddLodging(Lodging aLodging, int touristicPointId);

        void RemoveLodging(int lodgingId);

        void ModifyLodgingCapacity(int lodgingId, bool isFull);

        void ModifyReservationState(ReservationUpdateModel reservationUpdate);

        Administrator AddAdmin(Administrator anAdmin);

        void RemoveAdmin(int adminId);

        void ModifyAdmin(Administrator admin);

        Lodging AddReflectionLodging(Lodging lodging);

    };
}
