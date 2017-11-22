using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebApplication.Validations;

namespace WebApplication.Models
{
    public class UserViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        [StringLength(32)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        [StringLength(32)]
        [EmailValidation]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(32)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(32)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(32)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your adress")]
        [StringLength(32)]
        public string Adress { get; set; }


    }                  
}