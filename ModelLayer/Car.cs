using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public FuelType Fuel { get; set; }
        public int PassengerCapacity { get; set; }
        public int KilometersDriven { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }

    public enum FuelType
    {
        Unknown,
        Gasoline, 
        Diesel,
        Electricity
    }
}
