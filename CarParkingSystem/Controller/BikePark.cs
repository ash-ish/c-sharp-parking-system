using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem
{
    class BikePark
    {
        public static Dictionary<int, Bike> fixedSlots = new Dictionary<int, Bike>();
        public static Dictionary<int, Bike> fcfsSlots = new Dictionary<int, Bike>();
        public static List<int> WaitList = new List<int>();
        public static Dictionary<int, int> RejectionCount = new Dictionary<int, int>();

    }
}
