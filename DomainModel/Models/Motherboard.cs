namespace DomainModel.Models
{
    using System;
    public class Motherboard : Item
    {
        [Obsolete]
        public Motherboard()
        {
        }
        public Motherboard(string name, string brand, CATEGORY category, double price, string description, string mbModel, string format, string processorSocket,
           string processorManufacturer, string hddInterface, string memoryType, bool videoConnection, bool audioConnection) : 
           base(name, brand, category, price,  description)
        {

            if (string.IsNullOrWhiteSpace(mbModel))
            {
                throw new ArgumentException(nameof(mbModel) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(format))
            {
                throw new ArgumentException(nameof(format) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(processorSocket))
            {
                throw new ArgumentException(nameof(processorSocket) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(processorManufacturer))
            {
                throw new ArgumentException(nameof(processorManufacturer) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(hddInterface))
            {
                throw new ArgumentException(nameof(hddInterface) + " is null.");
            }
            if (string.IsNullOrWhiteSpace(memoryType))
            {
                throw new ArgumentException(nameof(memoryType) + " is null.");
            }


            MbModel = mbModel;
            Format = format;
            ProcessorSocket = processorSocket;
            ProcessorManufacturer = processorManufacturer;
            HDDInterface = hddInterface;
            MemoryType = memoryType;
            VideoConnection = videoConnection;
            AudioConnection = AudioConnection;
        }


        public virtual string MbModel
        {
            get;
            set;  
        }

        public virtual string Format
        {
            get;
            set;
        }

        public virtual string ProcessorSocket
        {
            get;
            set;
        }

        public virtual string ProcessorManufacturer
        {
            get;
            set;

        }

        public virtual string HDDInterface
        {
            get;
            set;
        }

        public virtual string MemoryType
        {
            get;
            set;
        }

        public virtual bool VideoConnection
        {
            get;
            set;
        }

        public virtual bool AudioConnection
        {
            get;
            set;
        }

        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, Brand: {Brand}, Model: {MbModel}, " +
        $"Format: {Format}, Processor socket: {ProcessorSocket}, Processor manufacturer: {ProcessorManufacturer}, HDD interface: {HDDInterface}, " +
        $"Memory type: {MemoryType}, Video connection: {(VideoConnection == true ? "Yes" : "No")}, Audio connection: {(AudioConnection == true ? "Yes" : "No")}";

    }
}

