
namespace DomainModel.Shop
{
    using System;
    using Models;

    public class BuyItem : Entity
    {

        [Obsolete]
        public BuyItem()
        { }
        public BuyItem(Item item, int quantity = 1)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item) + " is null");
            }
 
            Item = item;
            Quantity = quantity;
        }

        public BuyItem(Order order, Item item, int quantity = 1)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item) + " is null");
            }
            Order = order;
            Item = item;
            Quantity = quantity;
        }

        public virtual int Quantity
        {
            get;
            set;      
        }

        public virtual Item Item
        {
            get;
            protected set;
        }

        public virtual Order Order
        {
            get;
            protected set;
        }

        public virtual double CalcPrice() => Item.Price * Quantity;

        public virtual bool UpdateQuanity(int newQuantity)
        {
            if (newQuantity > 0 && newQuantity < 100)
            {
                Quantity = newQuantity;
                return true;
            }

            return false; 
        }

        public override string ToString() => $"Item name: {Item.Name} \tCategory: {Item.Category}\n";

      
    }
    
}
