
namespace E_shopProject
{
    class BuyItem
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
            Item = item;
            Quantity = quantity;
        }

        //Expression-Bodied
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
