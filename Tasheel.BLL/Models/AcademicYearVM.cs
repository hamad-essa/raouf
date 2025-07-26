using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Models
{
    public class AcademicYearVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Year must be fewer than 25 characters")]
        public string Year { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}
