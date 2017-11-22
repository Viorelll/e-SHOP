namespace DomainModel.Models
{
    using System;
    using Interfaces;
    public class Laptop : Item, IItemComponent
    {
        [Obsolete]
        public Laptop()
        {            
        }
        public Laptop(string name, string brand, CATEGORY category, double price, string description, string laptopModel, string sistemOperation, 
            string displayType, double displaySize, Resolution resolution, string processorManufacturer, string processorModel, 
            int processorFrequency, int memoryCapacity, int hddCapacity, double weight, string videocardModel,
            bool wifiConnection, bool bluetoothConnection) : base(name, brand, category, price,  description)
        {

            if (string.IsNullOrWhiteSpace(laptopModel))
            {
                throw new ArgumentException(nameof(laptopModel) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(sistemOperation))
            {
                throw new ArgumentException(nameof(sistemOperation) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(processorManufacturer))
            {
                throw new ArgumentException(nameof(processorManufacturer) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(processorModel))
            {
                throw new ArgumentException(nameof(processorModel) + " is null.");
            }
            if (processorFrequency <= 0 )
            {
                throw new ArgumentException(nameof(processorFrequency) + " must be positive.");
            }
            if (displaySize <= 0)
            {
                throw new ArgumentException(nameof(displaySize) + " must be positive.");
            }
            if (memoryCapacity <= 0 )
            {
                throw new ArgumentException(nameof(memoryCapacity) + " must be positive.");
            }
            if (hddCapacity <= 0)
            {
                throw new ArgumentException(nameof(hddCapacity) + " must be positive.");
            }
            if (weight <= 0)
            {
                throw new ArgumentException(nameof(weight) + " must be positive.");
            }
            if (string.IsNullOrWhiteSpace(videocardModel))
            {
                throw new ArgumentException(nameof(videocardModel) + " is null.");
            }

            LaptopModel = laptopModel;
            SistemOperation = sistemOperation;
            DisplayType = displayType;
            DisplaySize = displaySize;
            Resolution = resolution;
            ProcessorManufacturer = processorManufacturer;
            ProcessorModel = processorModel;
            ProcessorFrequency = processorFrequency;
            MemoryCapacity = memoryCapacity;
            HDDCapacity = hddCapacity;
            Weight = weight;
            VideocardModel = videocardModel;
            WifiConnection = wifiConnection;
            BluetoothConnection = bluetoothConnection;
        }



        public virtual string LaptopModel
        {
            get;
            set;
        }

        public virtual string SistemOperation
        {
            get;
            set;
        }

        public virtual string DisplayType
        {
            get;
            set;
        }

        public virtual double DisplaySize
        {
            get;
            set;
        }

        public virtual Resolution Resolution
        {
            get;
            set;
        }
        public virtual string ProcessorManufacturer
        {
            get;
            set;
        }

        public virtual string  ProcessorModel
        {
            get;
            set;
        }

        public virtual int ProcessorFrequency
        {
            get;
            set;
        }

        public virtual int MemoryCapacity
        {
            get;
            set;

        }

        public virtual int HDDCapacity
        {
            get;
            set;

        }
        public virtual double Weight
        {
            get;
            protected set;

        }
        public virtual string VideocardModel
        {
            get;
            set;

        }


        public virtual bool WifiConnection
        {
            get;
            set;
        }

        public virtual bool BluetoothConnection
        {
            get;
            set;

        }

        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, Brand: {Brand}, Model: {LaptopModel}, " +
            $"Sistem operation: {SistemOperation}, Display type: {DisplayType}, Resolution: {Resolution}, Processor manufucaturer: {ProcessorManufacturer}, " +
            $"Processor model: {ProcessorModel}, Processor frequency: {ProcessorFrequency}, Memory: {MemoryCapacity}, HDD: {HDDCapacity}, Weight: {Weight}, " +
            $"Video cart: {VideocardModel}, Wifi connection: {(WifiConnection == true ? "Yes" : "No")}, Bluetooth connection: {(BluetoothConnection == true ? "Yes" : "No")}";


        public virtual void AddGift()
        {
            Console.WriteLine(this.ToString());
        }

    }

   
}
