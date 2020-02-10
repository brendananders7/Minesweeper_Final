using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Models
{
    public class UserModel
    {
        [Required]
        [DisplayName("First Name")]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Gender")]
        [MaxLength(6)]
        public string Gender { get; set; }
        [Required]
        [DisplayName("Age")]
        [Range(0,100)]
        public int Age { get; set; }
        [Required]
        [DisplayName("State")]
        [MaxLength(30)]
        public string State { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Username")]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(35)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}