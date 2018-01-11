using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JaiSmi.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage="Please enter a first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Please enter a last name")]
        public string LastName { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage="Please enter an email address")]
        [EmailAddress(ErrorMessage="Please enter a valid email address")]
        public string EmailAddress { get; set; }
        public string Bio { get; set; }
        public string Url { get; set; }
        public string Avatar { get; set; }
        [Required(ErrorMessage="Please enter a password")]
        [MinLength(6, ErrorMessage = "Minimum length of password required is 6")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage="The passwords do not match")]
        public string RetypedPassword { get; set; }
    }
}