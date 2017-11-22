namespace DomainModel.Shop
{
    using Models;
    using System;
    public abstract class User : Entity
    {
        private string _username;
        private string _password;

        [Obsolete]
        protected User()
        { }
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

            _username = userName;
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            Email = email;
            _password = password;
        }

        public virtual string Username
        {
            get { return _username; } 
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length > 32))
                {
                    throw new ArgumentException(nameof(value) + " is null or too long.");
                }

                _username = value;
            }
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string FirstName
        {
            get;
            set;
        }

        public virtual string LastName
        {
            get;
            set;
        }

        public virtual string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length > 32))
                {
                    throw new ArgumentException(nameof(value) + " is null or too long.");
                }

                _password = value;
            }
        }

        public virtual string Adress
        {
            get;
            set;
        }

        // TO DO
        public virtual  bool Login()
        { return true; }

        public virtual bool Register()
        { return true; }

        public virtual bool UpdateProfile()
        { return true; }

        public virtual bool VerifyLogin()
        { return true; }

    }
}
