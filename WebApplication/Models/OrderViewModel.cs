namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    public class OrderViewModel
    {

        public enum ORDER_STATUS { New = 1, Shipped = 2, Delivered = 3 }
        public long Id { get; set; }
        public DateTime DateCreated { get; }
        public DateTime DateShipped { get; }
        public ORDER_STATUS OrderStatus { get; }
        public CustomerViewModel Customer { get; set;}
        public string ShipTo { get; }
        public IList<BuyItemViewModel> OrderBuyItems { get; set; }
       

    }
}