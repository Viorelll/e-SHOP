using System;

namespace WebApplication.Models
{
    public class BuyItemViewModel
    {
        public BuyItemViewModel()
        {
        }

        public BuyItemViewModel(ItemViewModel item, int quantity = 1)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item) + " is null");
            }

            Item = item;
            Quantity = quantity;
        }

        public BuyItemViewModel(OrderViewModel order, ItemViewModel item, int quantity = 1)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item) + " is null");
            }
            Order = order;
            Item = item;
            Quantity = quantity;
        }

        public long Id { get; set; }

        public int Quantity
        {
            get;
            set;
        }

        public ItemViewModel Item
        {
            get;
            set;
        }

        public OrderViewModel Order
        {
            get;
            set;
        }

        public double CalcPrice() => Item.Price * Quantity;

    }
}