using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tasheel.BLL.Models
{
   public class RegistrationVM
    {
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage ="Email Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MinLength(5, ErrorMessage = "MinLength is 5")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword Required")]
        [MinLength(5, ErrorMessage = "MinLength is 5")]
        [Compare("Password", ErrorMessage = "Password not match")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }


    }
}
