namespace P01_BillsPaymentSystem.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } //up to 50 characters, unicode
        public string LastName { get; set; } //(up to 50 characters, unicode) { get; set; }
        public string Email { get; set; } //up to 80 characters, non-unicode
        public string Password { get; set; } //up to 25 characters, non-unicode
    }
}
