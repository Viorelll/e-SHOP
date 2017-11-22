namespace Payment.Implementation
{
    using System;
    using Interfaces;
    internal class CreditCard : IPayment
    {      
        public void pay(double amount)
        {
            Console.WriteLine($"{amount:C} need pay with credit/debit card.");
        }

      
    }
}
