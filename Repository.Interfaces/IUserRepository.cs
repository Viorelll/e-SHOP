using System.Collections.Generic;
using DomainModel.Shop;

namespace Repository.Interfaces
{
    public interface IUserRepository : IRepository
    {
        void ModifyUsername(long id, string newUsername);
        void ModifyPassword(long id, string newPassword);

        //get all users
        IList<User> GetAll();

        //get user by id
        User GetUserById(long ? id);

        IList<string> GetUserEmails();

    }
}
