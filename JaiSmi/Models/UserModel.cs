using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaiSmi.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Avatar { get; set; }
    }
}