using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Models
{
    public class StudentVM
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Name must be fewer than 25 characters")]
        public string FullName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Religion { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Code { get; set; } 

        [Required]
        [StringLength(25, ErrorMessage = "Name must be fewer than 25 characters")]
        public string MotherName { get; set; }
        [Required]
        public DateTime MotherBirthday { get; set; }
        [Required]
        public string MotherNationality { get; set; }
        [Required]
        public string MotherJob { get; set; }
        [Required]
        public string MotherEducation { get; set; }
        [Required]
        public string MotherPhone { get; set; }
        [Required]
        public string MotherWorkPlace { get; set; }

        [ForeignKey(nameof(Nationality))]
        public int NationalityId { get; set; } //Fk
        public Nationality nationality { get; set; } //Np

          public virtual List<Card> Cards { get; set; } //Np

    }
}
