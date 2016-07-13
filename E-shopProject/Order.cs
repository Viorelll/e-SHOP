using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shopProject
{
    class Order
    {
        public string DateCreated
        {
            get;
            set;
        }

        public string DateShipped
        {
            get;
            set;
        }

        public bool Status
        {
            get;
            set;
        }

        public void PlaceOrder() { }
         
    }
}
