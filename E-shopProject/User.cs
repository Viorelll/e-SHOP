using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shopProject
{
    class User
    {    
        public string Email
        {
            get;  
        }

        public string FirstName
        {
            get;
        }

        public string LastName
        {
            get;
        }

        public string Password
        {
            get;
        }

        public string Adress
        {
            get;
        }

        public User(string firstName, string lastName, string adress, string email, string passwod)
        {
            if (firstName == null)
            {
                throw new Exception(nameof(firstName) + " is null");
            }
            if (lastName == null)
            {
                throw new Exception(nameof(lastName) + " is null");
            }
            if (passwod == null)
            {
                throw new Exception(nameof(passwod) + " is null");
            }

            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            Email = email;
            Password = passwod;
        }

        // TO DO
        public bool Login()
        { return true; }

        public bool Register()
        { return true; }

        public bool UpdateProfile()
        { return true; }

        public bool VerifyLogin()
        { return true; }

    }
}
