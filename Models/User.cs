
using _18_MVC_Example.ValidationClasses;
using System.ComponentModel.DataAnnotations;

namespace _18_MVC_Example.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username can not pass empty")]

        [UserPassValidation(ErrorMessage ="Wrong User name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can not pass empty")]

        [UserPassValidation(ErrorMessage = "Wrong password")]
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
