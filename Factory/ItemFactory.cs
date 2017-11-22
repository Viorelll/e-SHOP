namespace Factory
{
    using System;
    using Notification.Interfaces;
    using DomainModel.Models;
    using DomainModel.Interfaces;

    public interface IItemOptions
    {
        IItemOptions WithDiscount(int discount, string discountDescription);
        void PrintDiscount();   
    }
    public sealed class ItemFactory
    {
        private MakeGift _makeGift = new MakeGift();
        private IProductNotification _productNotification;
        private static readonly Lazy<ItemFactory> lazy = new Lazy<ItemFactory>(() => new ItemFactory(), true);
        private ItemFactory() { }
        public static ItemFactory Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public ItemFactory(IProductNotification productNotification)
        {
            _productNotification = productNotification;
        }

        public Monitor CreateNewMonitor(string name, string brand, CATEGORY category, double price, double size, string type, string model, 
            Action<IItemOptions> optionalParams = null)
        {
            var monitor = new Monitor(name, brand, category, price, null, size, type, model);

            IItemOptions options = new ItemOptions();
            if (optionalParams != null)
            {
                optionalParams(options);
                options.PrintDiscount();
            }
               
            OnItemCreation(monitor);

            return monitor;
        }

        public CPU CreateNewCPU(string name, string brand, CATEGORY category, double price, int cpuModel, string familyName, int frequency, 
            Action<IItemOptions> optionalParams = null)
        {
            var cpu = new CPU(name, brand, category, price, null, cpuModel, familyName, frequency);

            IItemOptions options = new ItemOptions();
            if (optionalParams != null)
            {
                optionalParams(options);
                options.PrintDiscount();
            }

            OnItemCreation(cpu);
            return cpu;
        }
        public Laptop CreateNewLaptop(string name, string brand, CATEGORY category, double price, string model, string sistemOperation,string displayType,
            double displaySize, Resolution resolution, string processorManufacturer, string processorModel, int processorFrequency, int memoryCapacity, 
            int hddCapacity, double weight, string videocardModel, bool wifiConnection, bool bluetoothConnection, Action<IItemOptions> optionalParams = null)
        {
            var laptop = new Laptop(name, brand, category, price, null, model, sistemOperation, displayType, displaySize, resolution, processorManufacturer, 
                processorModel, processorFrequency, memoryCapacity, hddCapacity, weight, videocardModel, wifiConnection, bluetoothConnection);

            IItemOptions options = new ItemOptions();
            if (optionalParams != null)
            {
                optionalParams(options);
                options.PrintDiscount();
            }

            OnItemCreation(laptop);
            return laptop;
        }
        public RAM CreateNewRAM(string name, string brand, CATEGORY category, double price, string type, int capacity, int frequency,
            Action<IItemOptions> optionalParams = null)
        {
            var ram = new RAM(name, brand, category, price, null, type, capacity, frequency);

            IItemOptions options = new ItemOptions();
            if (optionalParams != null)
            {
                optionalParams(options);
                options.PrintDiscount();
            }

            OnItemCreation(ram);
            return ram;
        }
        public Motherboard CreateNewMotherboard(string name, string brand, CATEGORY category, double price,  string model, string format, string processorSocket,
           string processorManufacturer, string hddInterface, string memoryType, bool videoConnection, bool audioConnection,
           Action<IItemOptions> optionalParams = null)
        {
            var motherboard = new Motherboard(name, brand, category, price, null, model, format, processorSocket, processorManufacturer, hddInterface, 
                memoryType, videoConnection, audioConnection);

            IItemOptions options = new ItemOptions();
            if (optionalParams != null)
            {
                optionalParams(options);
                options.PrintDiscount();
            }

            OnItemCreation(motherboard);
            return motherboard;
        }
        public Mouse CreateNewMouse(string name, string brand, CATEGORY category, double price, string model, string type, int dpi, 
            Action<IItemOptions> optionalParams = null)
        {
            var mouse = new Mouse(name, brand, category, price, null, model, type, dpi);

            IItemOptions options = new ItemOptions();
            if (optionalParams != null)
            {
                optionalParams(options);
                options.PrintDiscount();
            }

            OnItemCreation(mouse);
            return mouse;
        }
        public Keyboard CreateNewKeyboard(string name, string brand, CATEGORY category, double price, string model, string type, string keyboardInterface,
          Action<IItemOptions> optionalParams = null)
        {
            var keyboard = new Keyboard(name, brand, category, price, null, model, type, keyboardInterface);

            IItemOptions options = new ItemOptions();
            if (optionalParams != null)
            {
                optionalParams(options);
                options.PrintDiscount();
            }

            OnItemCreation(keyboard);
            return keyboard;
        }

        public Webcam CreateNewWebcam(string name, string brand, CATEGORY category, double price, string model, string webcamInterface, double pixels, 
            Resolution videoResolution, Resolution photoResolution, Action<IItemOptions> optionalParams = null)
        {
            var webcam = new Webcam(name, brand, category, price, null, model, webcamInterface, pixels, videoResolution, photoResolution);

            IItemOptions options = new ItemOptions();
            if (optionalParams != null)
            {
                optionalParams(options);
                options.PrintDiscount();
            }

            OnItemCreation(webcam);
            return webcam;
        }

        public void CreateLapotpWithMouse(Laptop l, Mouse m)
        {
            IItemComponent laptop = l;
            IItemComponent laptopWithMouse = m;
            m.SetMouseComponent(l);

            _makeGift.PrepareGift(laptopWithMouse);
        }
        public void CreateLapotpWithMouseAndKeyboard(Laptop l, Mouse m, Keyboard k)
        {
            IItemComponent laptop = l;
            IItemComponent laptopWithMouse = m;
            m.SetMouseComponent(l);
            IItemComponent laptopWithMouseAndKeyboard = k;
            k.SetKeyboardComponent(m);

            _makeGift.PrepareGift(laptopWithMouseAndKeyboard);
        }
        public void CreateLapotpWithMouseAndKeyboardAndWebcam(Laptop l, Mouse m, Keyboard k, Webcam w)
        {
            IItemComponent laptop = l;
            IItemComponent laptopWithMouse = m;
            m.SetMouseComponent(l);
            IItemComponent laptopWithMouseAndKeyboard = k;
            k.SetKeyboardComponent(m);
            IItemComponent laptopWithMouseAndKeyboardAndWebcam = w;
            w.SetWebcamComponent(k);

            _makeGift.PrepareGift(laptopWithMouseAndKeyboardAndWebcam);
        }
        private void OnItemCreation(Item item)
        {
            // Console.WriteLine($"New ! Product \"{item.Name}\" was added in store !");
            //_productNotification.Notify(item);
        }

        private class ItemOptions : IItemOptions
        {
            private int Discount
            {
                get;
                set;
            }
            private string Description
            {
                get;
                set;
            }
            public IItemOptions WithDiscount(int discount, string discountDescription)
            {
                if (string.IsNullOrWhiteSpace(discountDescription))
                {
                    throw new ArgumentException(nameof(discountDescription) + " is null.");
                }
                if (discount <= 0 || discount >= 100)
                {
                    throw new ArgumentException(nameof(discount) + " must be positive.");
                }
                Discount = discount;
                Description = discountDescription;
                return this;
            }
            public void PrintDiscount() => Console.WriteLine($"New discount of {Discount}% for {Description}");
           
        }

    }
}
