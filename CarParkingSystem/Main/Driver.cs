using CarParkingSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem
{
    class Driver
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main()
        {
            Availability available = new Availability();
            Valet valet = new Valet();
            Validation validate = new Validation();
            Input input = new Input();

            log.Info("------Parking Management System------");
            int choice;
            do
            {
                log.Info("Enter your choice");
                log.Info("1. Park Bike");
                log.Info("2. Park Car");
                log.Info("3. Take Bike");
                log.Info("4. Take Car");
                log.Info("5. Main Menu");
                log.Info("6. Exit");

                choice = input.TakeChoice();

                switch (choice)
                {
                    case 1:
                        input.parkBikeInput();
                        break;
                    case 2:
                        input.RemoveBikeInput();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            } while (choice != 6) ;

            valet.displayList();
            log.Info("Aane k Liye Dhanyawaad");
            Console.ReadKey();

        }
    }
}
