using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasheel.DAL.Entities
{

    public class Card
    {
        [Key]
        public int Id { get; set; }

        //-------------------------------------
        //البيانات الاولية

        [Required]
        public string AcademicClass { get; set; } //الصف الدراسي

        [Required]
        public string Education { get; set; }//تعليم متوسط ولا اساسي
        [Required]
        public string StudyPeriod { get; set; }//الفترة الدراسية

        //----------------------------------------
        // بيانات ولي الامر
        [Required]
        public string GuardianName { get; set; } //اسم ولي الامر
        [Required]
        public DateTime GuardianBirthday { get; set; } //تاريخ ميلاد ولي الامر

        [Required]
        public string GuardianGender { get; set; } //جنس ولي الامر

        [Required]
        public string GuardianJob { get; set; } //وظيفة ولي الامر
        [Required]
        public string GuardianWorkPlace { get; set; }//مكان العمل
        [Required]
        public string GuardianPhone { get; set; }//هاتف ولي الامر

        //--------------------------------------------------------------------
        //    بيانات الاجتماعيه عن الطالب
        [Required]
        public string FamilyCount { get; set; }//عدد افارد الاسرة
        [Required]
        public string Order { get; set; }//ترتيبه الاسري
        [Required]
        public string SiblingsCount { get; set; }//عدد الاخوة
        [Required]
        public string StudentLiving { get; set; }//معيشة الطالب
        [Required]
        public string AlternativeFamily { get; set; }//الاسرة البديلة
        [Required]
        public string TheArea { get; set; }//المنطقة
        [Required]
        public string TheStreet { get; set; }//الشارع
        public string? HouseNumber { get; set; }//رقم المنزل 
        [Required]
        public string HousePhone { get; set; }//هاتف المنزل
        [Required]
        public string? PointInterest { get; set; }//افرب نقطة دالة
        [Required]
        public string? Talents { get; set; }//المواهب 


        /// --------------------------------------------
        // الحاله الصحية للطالب
        [Required]
        public string PreviousIllnesses { get; set; } //الامراض التي سبق الاصابه بها
        [Required]
        public string DisabilityType { get; set; } //نوع الاعاقه الجسميه ان وجد
        [Required]
        public string Sight { get; set; }//النظر
        [Required]
        public string Hearing { get; set; }//السمع



        /////////////////////////// CV في حالة وجود مرض داخلي احضار ملف ورفعه



        //--------------------------------------------------
        //الظروف الاقتصاديه
        [Required]
        public string FamilyIncome { get; set; }//دخل الاسرة
        [Required]
        public string TypeHousing { get; set; }//نوع السكن
        [Required]
        public string BuildingType { get; set; }//نوع البناء
                                                //--------------------------------------------------
                                                // الجانب النفسي
        public string? Shyness { get; set; }//خجل
        public string? Fear { get; set; }//خوف
        public string? SuckingThumb { get; set; }//مص الابهام
        public string? NailBiting { get; set; }//قضم الاظافر
        public string? InvolutaryUrination { get; set; }//تبول لا ارادي
        public string? Daydreaming { get; set; }//سرحان
        public string? LowACDMO { get; set; }//ضعف الدافع الدراسي
        public string? Aggressive { get; set; }//سلوك عدواني
        public string? Stuttering { get; set; }//التأتاه
        public string? HyperActivity { get; set; }//فرط حركه
        public string? Notes { get; set; }//اخرى
                                          //------------------------------------------------------
                                          // الملاحظات
        public string? AnOpinion { get; set; }//رأي ولي الامر
        public string? Name { get; set; }// اسم ينوب ولي الامر
        public string? Kinship { get; set; }//صلة القرابة
        public string? Work { get; set; }//جهة العمل

        //----------------------------------//
        public int StudentId { get; set; } //Fk
        public Student student { get; set; } //Np
        public int AcademicYearId { get; set; } //Fk
        public AcademicYear academicYear { get; set; } //Np
                                                       //------------------------------------//

    }

}
