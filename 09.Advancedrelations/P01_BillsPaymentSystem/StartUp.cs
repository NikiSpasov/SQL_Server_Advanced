﻿namespace P01_BillsPaymentSystem.App
{
    using P01_BillsPaymentSystem.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BillsPaymentsSystemContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}