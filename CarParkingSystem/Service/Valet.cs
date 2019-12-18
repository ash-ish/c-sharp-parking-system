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
            string PlateNumber = Console.ReadLine();
            BikePark.fcfsSlots.Add(empID, new Bike() { name = BikeName, plateNumber = PlateNumber });
            log.Info("Your Bike is parked! :)");
        }


        public void removeBike(int empID)
        {
            DisplayBikeOfEmpID(empID);
            BikePark.fcfsSlots.Remove(empID);
            log.Info("Here is your bike. Byee :)");

        }


        public void displayList()
        {
            foreach(KeyValuePair<int, Bike> kvp in BikePark.fcfsSlots)
            {
                Bike bike = kvp.Value;
                log.Info("key  " + kvp.Key.ToString() + "bikename  " + bike.name + "plate number " + bike.plateNumber);
            }
        }


        public void DisplayBikeOfEmpID(int empID)
        {
            foreach (KeyValuePair<int, Bike> kvp in BikePark.fcfsSlots)
            {
                if(kvp.Key == empID)
                {
                    Bike bike = kvp.Value;
                    log.Info("bikename  " + bike.name + "plate number " + bike.plateNumber);
                }
            }
        }


    }
}