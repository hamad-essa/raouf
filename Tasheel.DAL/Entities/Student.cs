using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasheel.DAL.Entities
{

    public class Student
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Religion { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Code { get; set; } //الرقم الوطني او رقم الجواز
                                         //--------------------//



        //------------------------------------------------------------
        //بيانات عن الام
        [Required]
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
        public string MotherPhone { get; set; }//هاتف الام
        [Required]
        public string MotherWorkPlace { get; set; }//مكان عمل الام

        //--------------------------//
        [ForeignKey(nameof(Nationality))]
        public int NationalityId { get; set; } //Fk
        public Nationality? nationality { get; set; } //Np

        //--------------------------//
        public virtual List<Card> Cards { get; set; } //Np

    }
}
