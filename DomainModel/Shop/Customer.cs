using System.Collections.Generic;

namespace DomainModel.Shop
{
    using System;
    using Payment.Interfaces;

    public class Customer : User
    {
        private IList<Order> _customOrder;

        [Obsolete]
        public Customer()
        {
        }
      

        public Customer(string userName, string firstName, string lastName, string adress, string email, string password)
            :
                base(userName, firstName, lastName, adress, email, password)
        {
            _customOrder = new List<Order>();
        }

        public virtual IList<Order> CustomOrder
        {
            get { return _customOrder; }
            protected set { _customOrder = value; }
        }


        public virtual void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new Exception(nameof(order) + " is null");
            }

            CustomOrder.Add(order);
        }


        public virtual Cart CustomCart
        {
            get;
            protected set;
        }
        public virtual void SetCart(Cart cart)
        {
            if (cart == null)
            {
                throw new Exception(nameof(cart) + " is null");
            }

            CustomCart = cart;
        }

        public virtual void PaymentMethod(IPayment payment, double payAmount)
        {
            payment.pay(payAmount);
        }

        public override string ToString()
        {
           //CustomCart.ViewItems();
           return  $"\nFirst name: {FirstName}, Last name: {LastName}, Adress: {Adress}, Email: {Email}\n{CustomOrder}";
        } 



    }
}
