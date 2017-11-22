namespace DomainModel.Models
{
     using System;

    public abstract class Item : Entity
    {
  

        [Obsolete]
        protected Item()
        {
        }

        public Item(string name, string brand, CATEGORY category, double price, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException(nameof(brand) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                description = "No description";
            }
            if (price <= 0)
            {
                throw new ArgumentException(nameof(price) + " must be positive.");
            }

            Category = category;
            Name = name;
            Brand = brand;
            Price = price;
            Description = description;
        }

        public virtual string Description
        {
            get;
            set;
        }
        public virtual double UpdatePrice(double newPrice)
        {
            Price = newPrice;
            return Price;
        }

        public virtual double Price
        {
            get;
            set;
        }


        public virtual string Name {
            get;
            set;

        }


        public virtual string Brand {
            get;
            set;

        }
     

        public virtual CATEGORY Category
        {
            get;
            set;
        }

       
        
    }
}
