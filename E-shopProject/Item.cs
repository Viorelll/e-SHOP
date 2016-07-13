using System;

namespace E_shopProject
{
    abstract class Item  
    {
        private enum CATEGORY { Retea = 1, Componente, Periferice, Sisteme_Audio };
        private int _category;

        public double Price
        {
            get;
        }
        public string Name
        {
            get;   
        }
        public string Category
        {
            get
            {
                return $"{Enum.GetName(typeof(CATEGORY), _category)}";
            }

        }

        public Item(string name, int category, double price)
        {
            _category = category;
            Name = name;
            Price = price;
        }
        
    }
}
