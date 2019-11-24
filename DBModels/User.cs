using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Tools;

namespace DBModels
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class User
    {
        #region Properties
        [DataMember]
        public Guid Guid { get; private set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; private set; }
        [DataMember]
        public DateTime LastLoginDate { get; private set; }

        [DataMember]
        public List<Query> Queries { get; set; }
        #endregion

        #region Constructor

        public User(string firstName, string lastName, string email, string login, string password)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            LastLoginDate = DateTime.Now;

            SetPassword(password);
        }

        private User()
        {
            Guid = Guid.NewGuid();
            Queries = new List<Query>();
        }

        #endregion

        private void SetPassword(string password)
        {
            Password = Encrypting.GetMd5HashForString(password);
        }

        public bool CheckPassword(string password)
        {
            try
            {
                string res2 = Encrypting.GetMd5HashForString(password);
                return Password == res2;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckPassword(User user)
        {
            try
            {
                return Password == user.Password;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
