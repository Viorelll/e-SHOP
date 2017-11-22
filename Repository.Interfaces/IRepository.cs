namespace Repository.Interfaces
{
    using DomainModel.Models;
    public interface IRepository
    {
        void Save<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
        void Update<TEntity>(TEntity entity) where TEntity : Entity;
        void Dispose();

    }
}
