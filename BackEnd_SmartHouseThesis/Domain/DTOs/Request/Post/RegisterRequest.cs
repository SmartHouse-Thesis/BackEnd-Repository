using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Post
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]
        [Phone(ErrorMessage = "Invalid Phone")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^\w{8,}$", ErrorMessage = "Password must be at least 8 characters and contain a-z, A-Z, 0-9, and underscore characters")]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
