using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasheel.BLL.Models
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Email Invalid")]
        public string Email { get; set; } //تغيير كلمة المرور تكون عن طريق الايميل
    }
}
