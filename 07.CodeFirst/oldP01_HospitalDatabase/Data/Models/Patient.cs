namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        public int PatientId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email  { get; set; }

        public bool HasInsurance { get; set; }

    }
}
