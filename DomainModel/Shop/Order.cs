using System.Collections.Generic;

namespace DomainModel.Shop
{
    using Models;
    using System;
    public class Order : Entity
    {
        public enum ORDER_STATUS { New = 1, Shipped, Delivered };

        private Customer _customer;

        [Obsolete]
        protected Order()
        {  
        }

        public Order(string shipTo, ORDER_STATUS status, DateTime dateCreated, DateTime dateShipped)
        {
            if (string.IsNullOrWhiteSpace(shipTo))
            {
                throw new ArgumentException(nameof(shipTo) + " is null.");
            }

          
            ShipTo = shipTo;
            OrderStatus = status;
            DateCreated = dateCreated;
            DateShipped = dateShipped;
            OrderBuyItems = new List<BuyItem>();
        }
        public virtual DateTime DateCreated { get; }   
        public virtual DateTime DateShipped { get; }
        public virtual ORDER_STATUS OrderStatus { get; }

        public virtual Customer Customer
        {
            get { return _customer; }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(nameof(value) + " is null.");
                }

                _customer = value;
            }
        }

        public virtual string ShipTo { get; }

        public virtual void SetBuyItem(BuyItem buyItem)
        {
            OrderBuyItems.Add(buyItem);
        }

        public virtual IList<BuyItem> OrderBuyItems
        {
            get;
            protected set;
        }
        public virtual void PlaceOrder(Cart cart)
        {
            OrderBuyItems = cart.GetAllBuyItems();
        }

        public override string ToString()
        {
            return $"Shiping to adress: {ShipTo}\nDate created: {DateCreated}\nDateShipped: {DateShipped}\nOrder status: {OrderStatus}";
        }
    }
}
