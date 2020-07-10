using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManegement.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "The Email Address is not valid")]
        [Required(ErrorMessage = "Please enter an email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(6,ErrorMessage = "Password should be atleast 6 symbols")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
