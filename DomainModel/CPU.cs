namespace DomainModel.Models
{
    using System;
    public class CPU : Item
    {
        [Obsolete]
        protected CPU()
        {
        }
        public CPU(string name, string brand, CATEGORY category, double price, string description, int cpuModel, string familyName, int frequency) : 
            base(name, brand, category, price, description)
        {
            if (100 > cpuModel || cpuModel > 10000)
            {
                throw new ArgumentException(nameof(cpuModel) + " is wrong.");
            }
            if (string.IsNullOrWhiteSpace(familyName))
            {
                throw new ArgumentException(nameof(familyName) + " is null.");
            }
            if (1000 > frequency || frequency >= 7000)
            {
                throw new ArgumentException(nameof(frequency) + " is wrong.");
            }

            CpuModel = cpuModel;
            FamilyName = familyName;
            Frequency = frequency;
        }
        public int CpuModel
        {
            get;
            protected set;
        }

        public string FamilyName
        {
            get;
            protected set;
        }

        public int Frequency
        {
            get;
            protected set;
        }


        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, CPU: {CpuModel}, family name: {FamilyName}, frequency: {Frequency}, brand: {Brand}";
        

    }
}
