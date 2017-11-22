namespace Notification.Implementation
{
    using System;
    using DomainModel.Models;
    using Interfaces;
    internal class ProductTrackTraceNotification : IProductNotification
    {
        public void Notify(Item item)
        {
            Console.WriteLine($"Location: Chisinau - Product {item.Name}");
        }
    }
}
