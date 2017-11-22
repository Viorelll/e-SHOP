namespace E_shopProject
{
    using System;
    public class Order
    {
        public enum ORDER_STATUS { New = 1, Shipped, Delivered };

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
        }
        public DateTime DateCreated { get; }   
        public DateTime DateShipped { get; }
        public ORDER_STATUS OrderStatus{ get; }
        public string ShipTo { get; }
        public void PlaceOrder() { }

        public override string ToString()
        {
            return $"Shiping to adress: {ShipTo}\nDate created: {DateCreated}\nDateShipped: {DateShipped}\nOrder status: {OrderStatus}";
        }
    }
}
