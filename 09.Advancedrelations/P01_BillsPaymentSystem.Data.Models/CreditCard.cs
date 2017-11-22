namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwed { get; set; }
        public decimal LimitLeft { get; set; } //calculated property, not included in the database)  - ignore?
        public DateTime ExpirationDate  { get; set; }


    }
}
