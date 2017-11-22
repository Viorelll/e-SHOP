namespace DomainModel.Models
{
    using System;
    using Interfaces;
    public class Webcam : Item, IItemComponent
    {
        private IItemComponent _itemComponent;

        [Obsolete]
        public Webcam()
        { }
        public Webcam(string name, string brand, CATEGORY category, double price, string description, string webcamModel, string webcamInterface, double pixels, Resolution videoResolution,
            Resolution photoResoluton) : 
            base(name, brand, category, price, description)
        {

            if (string.IsNullOrWhiteSpace(webcamModel))
            {
                throw new ArgumentException(nameof(webcamModel) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(webcamInterface))
            {
                throw new ArgumentException(nameof(webcamInterface) + " is null.");
            }
            if (pixels <= 0)
            {
                throw new ArgumentException(nameof(pixels) + " must be positive.");
            }

            WebcamModel = webcamModel;
            WebcamInterface = webcamInterface;
            Pixels = pixels;
            VideoResolution = videoResolution;
            PhotoResolution = photoResoluton;
        }
        public virtual void SetWebcamComponent(IItemComponent itemComponent)
        {
            if (itemComponent != null)
                _itemComponent = itemComponent;
            else
                throw new ArgumentException(nameof(itemComponent) + " is null.");
        }



        public virtual string WebcamModel
        {
            get;
            set;
        }


        public virtual string WebcamInterface
        {
            get;
            set;
        }
        public virtual double Pixels
        {
            get;
            set;
        }

        public virtual Resolution VideoResolution
        {
            get;
            set;
        }

        public virtual Resolution PhotoResolution
        {
            get;
            set;
        }

        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, Brand: {Brand}, Model: {WebcamModel},"+ 
                $"Interface: {WebcamInterface}, Pixels: {Pixels}, Video resolution: {VideoResolution}, Photo resolution: {PhotoResolution}";

        public virtual void AddGift()
        {
            _itemComponent.AddGift();
            Console.WriteLine(this.ToString());
        }
    }
}