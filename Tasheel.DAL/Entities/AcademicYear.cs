using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tasheel.DAL.Entities
{
   
    public class AcademicYear
    {
        public int Id { get; set; }
      
        public string Year { get; set; }   //السنه الدراسية
                                           //-----------------------------------//
        public virtual List<Card> Cards { get; set; } //Np
        
    }
}
