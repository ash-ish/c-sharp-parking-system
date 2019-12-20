using System;
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
            int choice = 0;
            bool CorrectChoice = false;
           // string input = Console.ReadLine();
            while(CorrectChoice == false)
            {
                string input = Console.ReadLine();
                // bool CheckChoice = true;
                if (int.TryParse(input, out choice) == false)
                {
                    log.Info("Please enter a valid Choice");

                    //input = Console.ReadLine();
                    // CheckChoice = false;
                }
                else
                {
                    CorrectChoice = true;
                }
                /*
                if (CheckChoice)
                {
                    if (choice >= 1 && choice <= 5)
                    {
                        CorrectChoice = true;
                        //input = Console.ReadLine();
                    }
                    else
                    {
                        log.Info("Please enter a valid Choice");
                    }
                }*/
            }
            return choice;
        }


        public void parkBikeInput()
        {
            int empID = TakeID();
            if (available.IsEligibleForBikeParking(empID) == true)
            {
                valet.parkBike(empID);
            }else
            {
                log.Info(available.InconvinienceReasonForBike());
            }
        }

        public void parkCarInput()
        {
            int empID = TakeID();
            string type = TakeCarType();
            if (available.IsEligibleForCarParking(empID, type) == true)
            {
                valet.parkCar(empID, type);
            }
            else
            {
                log.Info(available.InconvinienceReasonForCar());
            }
        }


        public bool ValidateCarType(string CarType)
        {
            bool ValidType = false;
            if (string.Equals(CarType, "big", StringComparison.OrdinalIgnoreCase))
            {
                ValidType = true;
            }
            else if (string.Equals(CarType, "small", StringComparison.OrdinalIgnoreCase))
            {
                ValidType = true;
            }

            return ValidType;
        }


        public string TakeCarType()
        {
            log.Info("Enter Car Type  Big(SUV/Sedan) or Small(others)");
            string type = Console.ReadLine();
            bool ValidType = ValidateCarType(type);
            while (ValidType == false)
            {
                log.Info("Please enter valid Car Type");
                type = Console.ReadLine();
                ValidType = ValidateCarType(type);
            }
            return type;
        }


        

        public void RemoveBikeInput()
        {
            int empID = TakeID();
            bool OneBikeAlreadyParked = available.IsBikeAlreadyParked(empID);
            if (OneBikeAlreadyParked == true)
            {
                valet.removeBike(empID);
            }
            else
            {
                log.Info("No Bike Present for ID - " + empID);

            }
        }


        public void RemoveCarInput()
        {
            int empID = TakeID();
            bool OneCarAlreadyParked = available.IsCarAlreadyParked(empID);
            if (OneCarAlreadyParked == true)
            {
                valet.removeCar(empID);
            }
            else
            {
                log.Info("No Car Present for ID - " + empID);

            }
        }



    }
}
