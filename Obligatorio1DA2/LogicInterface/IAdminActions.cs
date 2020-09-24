using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface IAdminActions
    {
        //PRE:
        //POS: Login to the system as admin
        void Login(string mail, string password);

        //PRE:
        //POS: Add a new touristic point to the system
        void AddTouristicPoint(TouristicPoint aTouristicPoint);

        //PRE:
        //POS: Add a new lodging to the system
        void AddLodging(Lodging aLodging);

        //PRE:
        //POS: Remove an existing lodging of the system
        void RemoveLodging(int lodgingId);

        //PRE: 
        //POS: Modify the capacity (full/not full) of an existing lodging
        void ModifyLodgingCapacity(int lodgingId, bool isFull);

        //PRE: 
        //POS: Modify the state of an existing reservation
        void ModifyReservationState(int reservationId, string aDescription);

        //PRE:
        //POS: Add a new admin to the system
        void AddAdmin(Administrator anAdmin);

        //PRE:
        //POS: Remove an existing admin of the system
        void RemoveAdmin(int adminId);

    }
}
