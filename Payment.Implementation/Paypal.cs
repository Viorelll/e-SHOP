namespace Payment.Implementation
{
    using System;
    using Interfaces;

    internal class Paypal : IPayment
    {
        public virtual void pay(double amount)
        {
            Console.WriteLine($"{amount:C} need pay with Paypal account."); 
            
        }



    }
}
