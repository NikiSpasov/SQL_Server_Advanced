namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get; set; }
        public string BankName { get; set; } //up to 50 characters, unicode)
        public string  SWIFTCode  { get; set; } //up to 20 characters, non-unicode)
    }
}
