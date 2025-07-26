using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasheel.DAL.Entities
{
    public class Nationality
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } //اسم الجنسيه
        public virtual List <Student> students { get; set; } //Np


    }
}
