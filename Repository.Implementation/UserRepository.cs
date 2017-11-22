using System.Collections.Generic;
using DomainModel.Shop;
using NHibernate;
using Repository.Interfaces;

namespace Repository.Implementation
{
    internal class UserRepository : Repository, IUserRepository
    {
        public void ModifyUsername(long id, string newUsername)
        {
            using (ITransaction myTransaction = _session.BeginTransaction())
            {
                var user = _session.Get<User>(id);
                user.Username = newUsername;
                myTransaction.Commit();
            }
        }

        public void ModifyPassword(long id, string newPassword)
        {
            using (ITransaction myTransaction = _session.BeginTransaction())
            {
                var user = _session.Get<User>(id);
                user.Password = newPassword;
                myTransaction.Commit();
            }
        }

        public IList<User> GetAll()
        {
            return _session.QueryOver<User>().List();
        }

        public User GetUserById(long ? id)
        {
            return _session.QueryOver<User>()
                .Where(user => user.Id == id)
                .SingleOrDefault<User>();

        }

        public IList<string> GetUserEmails()
        {
            return _session.QueryOver<User>()
                .Select(c => c.Email)
                .List<string>();
        }
    }
}
