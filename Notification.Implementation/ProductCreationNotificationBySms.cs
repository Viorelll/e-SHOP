namespace Notification.Implementation
{
    using System;
    using DomainModel.Models;
    using Interfaces;

    internal class ProductCreationNotificationBySms : IProductNotification
    {
        public void Notify(Item item)
        {
            Console.WriteLine($"Send SMS: Product {item.Name}");
        }
    }
}
