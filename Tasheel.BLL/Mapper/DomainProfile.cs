using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tasheel.BLL.Models;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Mapper
{
    public class DomainProfile :Profile
    {
        public DomainProfile() 
        {
            CreateMap<Nationality, NationalityVM>();
            CreateMap<NationalityVM, Nationality>();

            CreateMap<Student, StudentVM>();
            CreateMap< StudentVM ,Student>();

            CreateMap<AcademicYear, AcademicYearVM>();
            CreateMap<AcademicYearVM, AcademicYear>();

            CreateMap<Card, CardVM>();
            CreateMap<CardVM, Card>();


        }
    }
}
