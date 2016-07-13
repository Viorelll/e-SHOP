using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shopProject
{
    class Monitor : Item
    {
       
        public Monitor(string name, int category, double price, string brand, int size, string type, string model) : base(name, category, price)
        {

            if (brand == null)
            {
                throw new Exception(nameof(brand) + " is null");
            }
            if (type == null)
            {
                throw new Exception(nameof(type) + " is null");
            }
            if (model == null)
            {
                throw new Exception(nameof(model) + " is null");
            }

            Brand = brand;
            DisplaySize = size;
            DisplayType = type;
            Model = model;
        }

        public string Brand
        {
            get;
            
        }

        public int DisplaySize
        {
            get;
        }

        public string DisplayType
        {
            get;
        }

        public string Model
        {
            get;
        }

        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, Brand: {Brand}, size: {DisplaySize}, type: {DisplayType}, model: {Model}";
        

       

    }
}
