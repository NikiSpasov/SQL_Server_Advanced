namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class Medicament
    {
        public int MedicamentId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}
