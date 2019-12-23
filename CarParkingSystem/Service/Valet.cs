using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem.Service
{
    class Valet
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void parkBike(int empID)
        {
            log.Info("Enter bike details -: ");
            log.Info("Enter bike name");
            string BikeName = Console.ReadLine();
            log.Info("Enter bike plate number");
            string BikePlateNumber = Console.ReadLine();
            BikePark.fcfsSlots.Add(empID, new Bike() { name = BikeName, plateNumber = BikePlateNumber });
            log.Info("Your Bike is parked! :)");
        }


        public void parkCar(int empID, string TypeOfCar)
        {
            log.Info("Enter Car details -: ");
            log.Info("Enter Car name");
            string CarName = Console.ReadLine();
            log.Info("Enter Car plate number");
            string CarPlateNumber = Console.ReadLine();
            if(string.Equals(TypeOfCar, "big", StringComparison.OrdinalIgnoreCase))
            {
                CarPark.BigfcfsSlots.Add(empID, new Car() { name = CarName,type = TypeOfCar, plateNumber = CarPlateNumber });
            }
            else
            {
                CarPark.SmallfcfsSlots.Add(empID, new Car() { name = CarName, type = TypeOfCar, plateNumber = CarPlateNumber });
            }
            log.Info("Your Car is parked! :)");
        }


        public void removeBike(int empID)
        {
            DisplayBikeOfEmpID(empID);
            BikePark.fcfsSlots.Remove(empID);
            log.Info("Here is your bike. Byee :)");
        }


        public void removeCar(int empID)
        {
            DisplayCarOfEmpID(empID);
            if (CarPark.BigfcfsSlots.ContainsKey(empID))
            {
                CarPark.BigfcfsSlots.Remove(empID);
            }
            else
            {
                CarPark.SmallfcfsSlots.Remove(empID);
            }
            log.Info("Here is your Car. Byee :)");
        }


        public void displayBikeList()
        {
            foreach(KeyValuePair<int, Bike> kvp in BikePark.fcfsSlots)
            {
                Bike bike = kvp.Value;
                log.Info("EmpID - " + kvp.Key + " bikename - " + bike.name + " plate number - " + bike.plateNumber);
            }
        }


        public void DisplayBikeOfEmpID(int empID)
        {
            foreach (KeyValuePair<int, Bike> kvp in BikePark.fcfsSlots)
            {
                if(kvp.Key == empID)
                {
                    Bike bike = kvp.Value;
                    log.Info("bikename  :" + bike.name + " plate-number  :" + bike.plateNumber);
                }
            }
        }


        public void AddToWaitList(int empID)
        {
            if (BikePark.RejectionCount.ContainsKey(empID))
            {
                if(BikePark.RejectionCount[empID] == 2)
                {
                    if(BikePark.fixedSlots.Count > 3)
                    {
                        BikePark.RejectionCount.Remove(empID);
                        BikePark.WaitList.Add(empID);
                        log.Info("It has been 3 times there is No parking slot available for you");
                        log.Info("So we are moving you in the waitlist of Fixed Parking Slot. :) (increasing population ;) )");
                    }else
                    {
                       // BikePark.fixedSlots.Add(empID, )
                        log.Info("It has been 3 times there is No parking slot available for you");
                        log.Info("So we are providing you a fixed slot :)  (increasing population ;) )");


                    }

                }
                else
                {
                    BikePark.RejectionCount[empID] += 1;
                }
            }
            else
            {
                BikePark.RejectionCount.Add(empID, 1);
            }
        }


        public void DisplayCarOfEmpID(int empID)
        {
            Dictionary<int, Car> TemporaryDictionary;
            if (CarPark.BigfcfsSlots.ContainsKey(empID))
            {
                TemporaryDictionary = CarPark.BigfcfsSlots;
            }
            else
            {
                TemporaryDictionary = CarPark.SmallfcfsSlots;
            }
            foreach (KeyValuePair<int, Car> kvp in TemporaryDictionary)
            {
                if (kvp.Key == empID)
                {
                    Car car = kvp.Value;
                    log.Info("bikename  : " + car.name + "    Type : " + car.type + "    plate-number  :" + car.plateNumber);
                }
            }
        }


    }
}