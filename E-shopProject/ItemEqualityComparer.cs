using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shopProject
{
    class ItemEqualityComparer : EqualityComparer<Item>
    {
        public override bool Equals(Item x, Item y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null | y == null)
                return false;
            else if (x.Name == y.Name && x.Category == y.Category)
                return true;
            else
                return false;
        }

        public override int GetHashCode(Item obj)
        {
            return (obj.Name + ";" + obj.Category).GetHashCode();
        }
    }
}
