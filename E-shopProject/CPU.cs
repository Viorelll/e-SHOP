using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shopProject
{
    class CPU : Item
    {

        public CPU(string name, int category, double price, int cpuModel, string familyName, int frequency, string manufacturer) : base(name, category, price)
        {
            if (name == null)
            {
                throw new Exception(nameof(name) + " is null");
            }
            if (familyName == null)
            {
                throw new Exception(nameof(familyName) + " is null");
            }
            if (manufacturer == null)
            {
                throw new Exception(nameof(manufacturer) + " is null");
            }

            CpuModel = cpuModel;
            FamilyName = familyName;
            Frequency = frequency;
            Manufacturer = manufacturer;
        }
        public int CpuModel
        {
            get;    
        }

        public string FamilyName
        {
            get;
        }

        public int Frequency
        {
            get;
        }

        public string Manufacturer
        {
            get;
        }

        public override string ToString() => $"Item: {base.Name}, Category: { base.Category}, Price: {base.Price}, CPU: {CpuModel}, family name: {FamilyName}, frequency: {Frequency}, manufacturer: {Manufacturer}";
        

    }
}
