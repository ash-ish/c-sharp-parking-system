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


        public void parkCar(int empID)
        {
            log.Info("Enter Car details -: ");
            log.Info("Enter Car name");
            //exception handling for wrong inputsssss
            string CarName = Console.ReadLine();
            log.Info("Enter Car Type  Big(SUV/Sedan)  Small(others)");
            string TypeOfCar = Console.ReadLine();
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
            log.Info("Your Bike is parked! :)");
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
                    log.Info("bikename  :" + car.name + " Type : " + car.type + " plate-number  :" + car.plateNumber);
                }
            }
        }


    }
}