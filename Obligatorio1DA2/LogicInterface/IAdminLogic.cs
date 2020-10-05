using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface IAdminLogic
    {
        //PRE:
        //POS: Add a new touristic point to the system
        TouristicPoint AddTouristicPoint(TouristicPoint aTouristicPoint, int regionId, int [] categories);

        //PRE:
        //POS: Add a new lodging to the system
        Lodging AddLodging(Lodging aLodging, int touristicPointId);

        //PRE:
        //POS: Remove an existing lodging of the system
        void RemoveLodging(int lodgingId);

        //PRE: 
        //POS: Modify the capacity (full/not full) of an existing lodging
        void ModifyLodgingCapacity(int lodgingId, bool isFull);

        //PRE: 
        //POS: Modify the state of an existing reservation
        void ModifyReservationState(int stateId, int reservationId, string aDescription);

        //PRE:
        //POS: Add a new admin to the system
        Administrator AddAdmin(Administrator anAdmin);

        //PRE:
        //POS: Remove an existing admin of the system
        void RemoveAdmin(int adminId);

    }
}
