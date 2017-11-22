namespace DomainModel.Models
{
    using System;
    public class RAM : Item
    {
        [Obsolete]
        public RAM()
        {
        }
        public RAM(string name, string brand, CATEGORY category, double price, string description, string type, int capacity, int frequency) : 
            base(name, brand, category, price, description)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException(nameof(brand) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException(nameof(type) + " is null.");
            }
            if (capacity <= 0)
            {
                throw new ArgumentException(nameof(capacity) + " must be positive.");
            }
            if (100 > frequency || frequency >= 5000)
            {
                throw new ArgumentException(nameof(frequency) + " is wrong.");
            }

            Type = type;
            Frequency = frequency;
            Capacity = capacity;

        }

  
        public virtual string Type
        {
            get;
            set;
        }

        public virtual int Capacity
        {
            get;
            set;
        }

        public virtual int Frequency
        {
            get;
            set;
        }

        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, Brand: {Brand}, Type: {Type}, Capacity: {Capacity}, Frequency: {Frequency}";

    }
}
