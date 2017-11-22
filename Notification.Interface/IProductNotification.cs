namespace Notification.Interfaces
{
    using DomainModel.Models;
    public interface IProductNotification
    {
        void Notify(Item item); 
    }
}
