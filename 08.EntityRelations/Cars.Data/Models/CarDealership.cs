using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Data.Models
{
    public class CarDealership
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int DealershipId { get; set; }
        public Dealership Dealership { get; set; }
    }
}
