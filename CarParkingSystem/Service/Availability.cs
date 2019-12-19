using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem.Service
{
    class Availability
    {
        BikePark bikePark = new BikePark();

        bool OneBikeAlreadyParked;
        bool SlotAvailable;

        public int CountBta()
        {
            return BikePark.fcfsSlots.Count();
        }

        public Boolean IsBikeSlotAvailable()
        {
            bool availability = true;
            if (BikePark.fcfsSlots.Count > 5)
            {
                availability = false;
            }
            return availability;
        }


        public Boolean IsBikealreadyParked(int empID)
        {
            bool present = false;
            if (BikePark.fcfsSlots.ContainsKey(empID))
            {
                present = true;
            }
            return present;
        }


        public Boolean IsEligibleForParking(int empID)
        {
            bool IsEligible = false;
            OneBikeAlreadyParked = IsBikealreadyParked(empID);
            SlotAvailable = IsBikeSlotAvailable();
            if(OneBikeAlreadyParked == false && SlotAvailable == true)
            {
                IsEligible = true;
            }
            return IsEligible;
           
        }


        public string InconvinienceReason()
        {
            string InconvinienceReason = "";

            if (OneBikeAlreadyParked)
            {
                InconvinienceReason = "Your Maximum Parking limit is Reached ! empID has one bike already parked ";
            }
            if(SlotAvailable == false)
            {
                InconvinienceReason = "No slot available";
            }
            return InconvinienceReason;
        }


    }
}