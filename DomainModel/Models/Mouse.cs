namespace DomainModel.Models
{
    using System;
    using Interfaces;
    public class Mouse : Item, IItemComponent
    {
        private IItemComponent _itemComponent;

        [Obsolete]
        public Mouse()
        {        
        }

        public Mouse(string name, string brand, CATEGORY category, double price, string description, string mouseModel, string type, int dpi) : 
            base(name, brand, category, price,  description)
        {
           
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException(nameof(brand) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(mouseModel))
            {
                throw new ArgumentException(nameof(mouseModel) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException(nameof(type) + " is null.");
            }
            if (dpi <= 0)
            {
                throw new ArgumentException(nameof(dpi) + " must be positive.");
            }


            MouseModel = mouseModel;
            Type = type;
            Dpi = dpi;

        }

        public virtual void SetMouseComponent(IItemComponent itemComponent)
        {
            if (itemComponent != null)
                _itemComponent = itemComponent;
            else
                throw new ArgumentException(nameof(itemComponent) + " is null.");
        }

        public virtual string MouseModel
        {
            get;
            set;
        }

        public virtual string Type
        {
            get;
            set;
        }

        public virtual int Dpi
        {
            get;
            set;
        }


        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, Brand: {Brand}, Model: {MouseModel}, Type: {Type}, DPI: {Dpi}";

        public virtual void AddGift()
        {
            _itemComponent.AddGift();
            Console.WriteLine(this.ToString());
        }
    }
}
