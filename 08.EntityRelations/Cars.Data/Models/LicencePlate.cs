using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Data.Models
{
    public class LicencePlate
    {
        public int  Id { get; set; }
        public string Number { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

    }
}
