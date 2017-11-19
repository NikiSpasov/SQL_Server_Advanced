namespace Cars.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public Make Make { get; set; }

        public string Model { get; set; }

        public int EngineId { get; set; }

        public Engine Engine { get; set; }

        public int Doors { get; set; }

        public Trasnmition Trasnmition { get; set; }

        public DateTime ProductionYear { get; set; }

        public ICollection<CarDealership> CarDealerships { get; set; } = new List<CarDealership>();

        public int? LicencePlateId { get; set; }

        public LicencePlate LicencePlate { get; set; }
    }
}