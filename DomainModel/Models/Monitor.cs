namespace DomainModel.Models
{
    using System;
    public class Monitor : Item
    {
        
        public Monitor()
        {
        }
       
        public Monitor(string name, string brand, CATEGORY category, double price, string description, double size, string type, 
            string monitorModel) : 
            base(name, brand, category, price,  description)
        {

            if (size < 10)
            {
                throw new ArgumentException(nameof(size) + " must to be bigger.");
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException(nameof(type) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(monitorModel))
            {
                throw new ArgumentException(nameof(monitorModel) + " is null.");
            }

            DisplaySize = size;
            DisplayType = type;
            MonitorModel = monitorModel;
        }

        public virtual double DisplaySize
        {
            get;
            set;
        }

        public virtual string DisplayType
        {
            get;
            set;
        }

        public virtual string MonitorModel
        {
            get;
            set;
        }

        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, Brand: {Brand}, size: {DisplaySize}, type: {DisplayType}, model: {MonitorModel}";

    }
}
