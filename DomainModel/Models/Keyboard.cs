namespace DomainModel.Models
{
    using System;
    using Interfaces;
    public class Keyboard : Item, IItemComponent
    {
        private IItemComponent _itemComponent;

        [Obsolete]
        public Keyboard()
        {
        }
        public Keyboard(string name, string brand, CATEGORY category, double price, string description,  string keyboardModel, string type, string keyboardInterface) : 
            base(name, brand, category, price, description)
        {         
            if (string.IsNullOrWhiteSpace(keyboardModel))
            {
                throw new ArgumentException(nameof(keyboardModel) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException(nameof(type) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(keyboardInterface))
            {
                throw new ArgumentException(nameof(keyboardInterface) + " is null.");
            }

            KeyboardModel = keyboardModel;
            Type = type;
            KeyboardInterface = keyboardInterface;

        }
        public virtual void SetKeyboardComponent(IItemComponent itemComponent)
        {
            if (itemComponent != null)
                _itemComponent = itemComponent;
            else
                throw new ArgumentException(nameof(itemComponent) + " is null.");
        }

        public virtual string KeyboardModel
        {
            get;
            set;
        }

        public virtual string Type
        {
            get;
            set;
        }

        public virtual string KeyboardInterface
        {
            get;
            set;
        }

        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, Brand: {Brand}, Model: {KeyboardModel}, Type: {Type}, Interface: {KeyboardInterface}";
       

        public virtual void AddGift()
        {
            _itemComponent.AddGift();
            Console.WriteLine(this.ToString());
        }
    }
}