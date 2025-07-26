using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Models
{
   public class NationalityVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25,ErrorMessage ="Name must be fewer than 25 characters")]
        public string Name { get; set; } 
        public virtual List<Student> students { get; set; }

       
    }
}
