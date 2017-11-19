namespace Cars.Data.Models
{
    using System.Collections.Generic;

    public class Dealership
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CarDealership> CarDealerships { get; set; }  =
            new List<CarDealership>();
    }
}
