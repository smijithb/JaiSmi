using JaiSmi.DAL.EntityModel;
using JaiSmi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return (from u in context.USERS
                        select new UserModel
                        {
                            Id = u.USER_ID,
                            FirstName = u.FIRST_NAME,
                            LastName = u.LAST_NAME,
                            Avatar = u.PROFILE_PIC,
                            Description = u.DESCRIPTION,
                            Url = u.URL
                        }).FirstOrDefault();
            }
        }

        public bool CreateUser(UserModel user)
        {
            bool isUserCreated = false;

            return isUserCreated;
        }

        
        #endregion

        #region Private Methods



        #endregion
    }
}