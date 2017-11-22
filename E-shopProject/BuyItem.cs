namespace E_shopProject
{
    using System;
    using DomainModel.Models;

    public class BuyItem 
    {
        public int Quantity
        {
            get;
            private set;      
        }

        public Item Item
        {
            get;
        }
        public BuyItem(Item item, int quantity = 1)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item) + " is null");
            }
            Item = item;
            Quantity = quantity;
        }

        public double CalcPrice() => Item.Price * Quantity;

        public bool UpdateQuanity(int newQuantity)
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
