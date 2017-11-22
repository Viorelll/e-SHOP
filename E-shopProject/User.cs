namespace E_shopProject
{
    using System;
    public abstract class User
    {    
        public string Username
        {
            get;
        }
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

        public User(string userName, string firstName, string lastName, string adress, string email, string password)
        {
            if (userName == null)
            {
                throw new ArgumentException(nameof(firstName) + " is null");
            }
            if (firstName == null)
            {
                throw new ArgumentException(nameof(firstName) + " is null");
            }
            if (lastName == null)
            {
                throw new ArgumentException(nameof(lastName) + " is null");
            }
            if (password == null)
            {
                throw new ArgumentException(nameof(password) + " is null");
            }

            Username = userName;
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            Email = email;
            Password = password;
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
