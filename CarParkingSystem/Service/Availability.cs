using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem.Service
{
    class Availability
    {

        bool OneBikeAlreadyParked;
        bool BikeSlotAvailable;
        bool OneCarAlreadyParked;
        bool CarSlotAvailable;

        Valet valet = new Valet();

        public Boolean IsBikeSlotAvailable()
        {
            bool availability = true;
            if (BikePark.fcfsSlots.Count > 5)
            {
                availability = false;
            }
            return availability;
        }


        private bool IsCarSlotAvailable(string CarType)
        {
            bool availability = true;
            if (string.Equals(CarType, "big", StringComparison.OrdinalIgnoreCase))
            {
                if (CarPark.BigfcfsSlots.Count > 5)
                {
                    availability = false;
                }
            }
            else
            {
                if (CarPark.SmallfcfsSlots.Count > 5)
                {
                    availability = false;
                }
            }
            return availability;
        }


        public Boolean IsBikeAlreadyParked(int empID)
        {
            bool present = false;
            if (BikePark.fcfsSlots.ContainsKey(empID))
            {
                present = true;
            }
            return present;
        }


        public Boolean IsCarAlreadyParked(int empID)
        {
            bool present = false;
            if (CarPark.BigfcfsSlots.ContainsKey(empID)  || CarPark.SmallfcfsSlots.ContainsKey(empID))
            {
                present = true;
            }
            return present;
        }


        public Boolean IsEligibleForCarParking(int empID, string CarType)
        {
            bool IsEligible = false;
            OneCarAlreadyParked = IsCarAlreadyParked(empID);
            CarSlotAvailable = IsCarSlotAvailable(CarType);
            if (OneCarAlreadyParked == false && CarSlotAvailable == true)
            {
                IsEligible = true;
            }
            return IsEligible;
        }


        public Boolean IsEligibleForBikeParking(int empID)
        {
            bool IsEligible = false;
            OneBikeAlreadyParked = IsBikeAlreadyParked(empID);
            BikeSlotAvailable = IsBikeSlotAvailable();
            if(OneBikeAlreadyParked == false && BikeSlotAvailable == true)
            {
                IsEligible = true;
            }
            if(BikeSlotAvailable == false)
            {
                valet.AddToWaitList(empID);
            }

            return IsEligible;
           
        }


        public string InconvinienceReasonForBike()
        {
            string InconvinienceReason = "";

            if (OneBikeAlreadyParked)
            {
                InconvinienceReason = "Your Maximum Parking limit of 1 has Reached ";
            }
            if(BikeSlotAvailable == false)
            {
                InconvinienceReason = "No slot available";
            }
            return InconvinienceReason;
        }


        public string InconvinienceReasonForCar()
        {
            string InconvinienceReason = "";

            if (OneCarAlreadyParked)
            {
                InconvinienceReason = "Your Maximum Parking limit of 1 has Reached !";
            }
            if (CarSlotAvailable == false)
            {
                InconvinienceReason = "No slot available";
            }
            return InconvinienceReason;
        }


    }
}