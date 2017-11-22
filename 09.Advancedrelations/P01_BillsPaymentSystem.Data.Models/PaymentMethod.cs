﻿namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class PaymentMethod
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public int UserId { get; set; }
        public int? BankAccountId { get; set; }
        public int? CreditCardId { get; set; }

        //Add check-constraint 
        //Only PaymentMethod’s BankAccountId and CreditCardId should be nullable, and you should make sure 
        //that always one of them is null and the other one is not 

        //composite key UserId, BankAccountId and CreditCardId!
    }
}