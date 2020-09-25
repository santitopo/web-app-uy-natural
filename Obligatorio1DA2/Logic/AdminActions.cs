using Domain;
using LogicInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AdminActions : IAdminActions
    {
        public void AddAdmin(Administrator anAdmin)
        {
            throw new NotImplementedException();
        }

        public void AddLodging(Lodging aLodging)
        {
            throw new NotImplementedException();
        }

        public void AddTouristicPoint(TouristicPoint aTouristicPoint)
        {
            throw new NotImplementedException();
        }

        public void Login(string mail, string password)
        {
            throw new NotImplementedException();
        }

        public void ModifyLodgingCapacity(int lodgingId, bool isFull)
        {
            throw new NotImplementedException();
        }

        public void ModifyReservationState(int reservationId, string aDescription)
        {
            throw new NotImplementedException();
        }

        public void ModifyReservationState(int reservationId, int stateId, string aDescription)
        {
            throw new NotImplementedException();
        }

        public void RemoveAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public void RemoveLodging(int lodgingId)
        {
            throw new NotImplementedException();
        }
    }
}
