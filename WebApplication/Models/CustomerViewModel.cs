using System;
using System.Collections.Generic;
using DomainModel.Shop;

namespace WebApplication.Models
{
    public class CustomerViewModel : UserViewModel
    {
        public IList<Order> CustomOrder { get; set;}
        public Cart CustomCart { get; set;}
 
    }
}