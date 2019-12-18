﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem.Service
{
    class Input
    {
        Availability available = new Availability();
        Valet valet = new Valet();
       
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public int TakeID()
        {
            log.Info("Enter your employee ID");
            int EmpID;
            string input = Console.ReadLine();
            bool validID = int.TryParse(input, out EmpID);
            while (validID == false)
            {
                log.Info("Please enter a valid ID");
                input = Console.ReadLine();
                validID = int.TryParse(input, out EmpID);
            }
            return EmpID;
        }


        public int TakeChoice()
        {
            int choice;
            string input = Console.ReadLine();
            while(int.TryParse(input, out choice) == false)
            {
                log.Info("Please enter a valid ID");
                input = Console.ReadLine();
            }
            return choice;
        }


        public void parkBikeInput()
        {
            int empID = TakeID();
            if (available.IsEligibleForParking(empID))
            {
                valet.parkBike(empID);
            }else
            {
                available.InconvinienceReason();
            }
        }

        public void RemoveBikeInput()
        {
            int empID = TakeID();
            bool OneBikeAlreadyParked = available.IsBikealreadyParked(empID);
            if (OneBikeAlreadyParked)
            {
                log.Info("No Bike Present for ID - " + empID);
            }else
            {
                valet.removeBike(empID);
            }
        }



    }
}