using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasheel.BLL.Models
{
    public class LoginVM
    {
     
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MinLength(5, ErrorMessage = "MinLength is 5")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
