namespace Repository.Implementation
{
    using DomainModel.Models;
    using NHibernate;
    using Interfaces;

    public abstract class Repository : IRepository
    {
        protected readonly ISession _session = SessionGenerator.Instance.GetSession();
        public void Save<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
             using (ITransaction transaction = _session.BeginTransaction())
             {
                _session.Delete(entity);
                transaction.Commit();
             }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Update(entity);
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
