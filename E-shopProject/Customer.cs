namespace E_shopProject
{
    using System;
    using Payment.Interfaces;
    public class Customer : User
    {
        public Customer(string userName, string firstName, string lastName, string adress, string email, string password) :
            base(userName, firstName, lastName, adress, email, password)
        { }
      
        public Order CustomOrder
        {
            get;
            private set;
        }

        public Cart CustomCart
        {
            get;
            private set;
        }


        public void SetOrder(Order order)
        {
            if (order == null)
            {
                throw new Exception(nameof(order) + " is null");
            }

            CustomOrder = order;
        }
        public void SetCart(Cart cart)
        {
            if (cart == null)
            {
                throw new Exception(nameof(cart) + " is null");
            }

            CustomCart = cart;
        }

        public void PaymentMethod(IPayment payment, double payAmount)
        {
            payment.pay(payAmount);
        }

        public override string ToString()
        {
           CustomCart.ViewItems();
           return  $"\nFirst name: {FirstName}, Last name: {LastName}, Adress: {Adress}, Email: {Email}\n{CustomOrder}";
        } 



    }
}
