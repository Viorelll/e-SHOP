using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shopProject
{
    class Customer : User
    {
        private Order _customOrder;
        private Cart _customCart;

        public Customer(string firstName, string lastName, string adress, string email, string passwod) : base(firstName, lastName, adress, email, passwod)
        {
        }

        public Order CustomOrder
        {
            get;
        }

        public Cart CustomCart
        {
            get;
        }


        public void SetOrder(Order order)
        {
            if (order == null)
            {
                throw new Exception(nameof(order) + " is null");
            }

            _customOrder = order;
        }
        public void SetCart(Cart cart)
        {
            if (cart == null)
            {
                throw new Exception(nameof(cart) + " is null");
            }

            _customCart = cart;
        }
      
        public override string ToString() => $"First name: {FirstName}, Last name: {LastName}, Adress: {Adress}, Email: {Email}";
        
    }
}
