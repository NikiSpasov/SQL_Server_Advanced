namespace P01_HospitalDatabase.Data.Models
{
    using System.Runtime.InteropServices.ComTypes;

    public class Diagnose
    {
        public int DiagnoseId { get; set; }

        public string Name  { get; set; }

        public string Comments { get; set; }

        public Patient Patient { get; set; }

        public int PatientId { get; set; }
    }
}
