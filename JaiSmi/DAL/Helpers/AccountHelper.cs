using JaiSmi.DAL.EntityModel;
using JaiSmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JaiSmi.DAL.Helpers
{
    public class AccountHelper
    {
        #region Public Methods

        public UserModel GetUser(string username, string password)
        {
            using (var context = new SJEntities())
            {
                string hashedPassword = EncryptPassword(password);

                return (from u in context.USERS
                        where u.USERNAME == username
                        && u.PASSWORD == hashedPassword
                        select new UserModel
                        {
                            Id = u.USER_ID,
                            FirstName = u.FIRST_NAME,
                            LastName = u.LAST_NAME,
                            Avatar = u.PROFILE_PIC,
                            Bio = u.BIO,
                            Url = u.URL
                        }).FirstOrDefault();
            }
        }

        public UserModel GetUser(string emailAddress)
        {
            using (var context = new SJEntities())
            {
                return GetUser(context, emailAddress);
            }
        }

        public bool CreateUser(UserModel user)
        {
            bool isUserCreated = false;

            using (var context = new SJEntities())
            {
                if (!IsUserExist(context, user.EmailAddress))
                {
                    var newUser = new USER();
                    newUser.USER_ID = Guid.NewGuid();
                    newUser.FIRST_NAME = user.FirstName;
                    newUser.LAST_NAME = user.LastName;
                    newUser.EMAIL_ADDRESS = user.EmailAddress;
                    newUser.PASSWORD = EncryptPassword(user.Password);
                    newUser.USERNAME = CreateUsername(user.FirstName, user.LastName);
                    newUser.PROFILE_PIC = user.Avatar;
                    newUser.URL = user.Url;
                    newUser.ADDED_DATE = DateTime.UtcNow;

                    context.USERS.Add(newUser);
                    context.SaveChanges();
                    isUserCreated = true;
                }
            }

            return isUserCreated;
        }

        public bool IsUserExist(string emailAddress)
        {
            using (var context = new SJEntities())
            {
                return IsUserExist(context, emailAddress);
            }
        }        

        public List<USER> GetAllUsers()
        {
            using (var context = new SJEntities())
            {
                return (from u in context.USERS
                        select u).ToList();
            }
        }
        
        #endregion

        #region Private Methods

        public string CreateUsername(string firstname, string lastname)
        {
            string username = string.Empty;

            if (!string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(lastname))
            {
                username = string.Concat(firstname.ToLower(), lastname.ToLower());
                var users = GetAllUsers();
                string newUsername = username;
                int counter = 1;

                while (IsUserExists(users, newUsername))
                {
                    newUsername = string.Concat(username, ++counter);
                }
            }       

            return username;
        }

        private bool IsUserExists(List<USER> users, string username)
        {
            return users.Exists(u => u.USERNAME == (username ?? string.Empty).ToLower());
        }

        private bool IsUserExist(SJEntities context, string emailAddress)
        {
            if (!string.IsNullOrWhiteSpace(emailAddress))
                return context.USERS.FirstOrDefault(u => u.EMAIL_ADDRESS == emailAddress) == null ? false : true;
            else
                return true;
        }

        private string EncryptPassword(string password)
        {
            if (!string.IsNullOrWhiteSpace(password))
            {
                SHA256 mySHA256 = SHA256Managed.Create();
                byte[] hash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return Convert.ToBase64String(hash); 
            }
            else
            {
                return null;
            }
        }

        private UserModel GetUser(SJEntities context, string emailAddress)
        {
            return (from u in context.USERS
                    where u.EMAIL_ADDRESS == emailAddress
                    select new UserModel
                    {
                        Id = u.USER_ID,
                        FirstName = u.FIRST_NAME,
                        LastName = u.LAST_NAME,
                        Avatar = u.PROFILE_PIC,
                        Bio = u.BIO,
                        Url = u.URL
                    }).FirstOrDefault();
        }

        #endregion
    }
}