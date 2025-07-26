using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasheel.BLL.Intrefaces;
using Tasheel.BLL.Models;
using Tasheel.BLL.Repository;
using Tasheel.DAL.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tasheel.PL.Controllers
{
    

    public class AcademicYearController : Controller
    {
        private readonly Iacademicyear academicyear;

        //نعطي علم اني بنستخدم اوتو مابر
        private readonly IMapper mapper;
        public AcademicYearController(Iacademicyear AC , IMapper mapper)
        {
           this .academicyear = AC;
            this .mapper = mapper;

        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var data = await academicyear.GetAllAsync();
            var result = mapper.Map<IEnumerable<AcademicYearVM>>(data);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
     
        [HttpPost]
        public async Task<IActionResult> Create(AcademicYearVM obj)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    // التحقق من وجود العام الدراسي مسبقًا
                    var existingYear = await academicyear.GetByYearAsync(obj.Year);
                    if (existingYear != null)
                    {
                        TempData["ErrorMsg"] = "هذا العام الدراسي موجود بالفعل ولا يمكن إضافته مرة أخرى.";
                        return View(obj);
                    }

                    //  تحويل النموذج إلى الكيان باستخدام AutoMapper
                    var details = mapper.Map<AcademicYear>(obj);
                    await academicyear.CreateAsync(details);
               
                    TempData["SuccessMsg"] = " تم إضافة العام الدراسي بنجاح.";
                    return RedirectToAction("Index");
                   
                //}
                //else
                //{
                //    TempData["ErrorMsg"] = " هناك خطأ في بيانات النموذج.";
                //    return View(obj);
                //}
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = " حدث خطأ أثناء الإضافة: {ex.Message}";
                return View(obj);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edeit(int Id)
        {
            var Data = await academicyear.GetByIdAsync(Id);
            var data = mapper.Map<AcademicYearVM>(Data);

            return View(Data);

        }
        [HttpPost]
        public async Task<IActionResult> Edeit(AcademicYearVM ob)
        {
            try

            {
                var data = mapper.Map<AcademicYear>(ob);
                await academicyear.EdeiteAsync(data);

                if (ModelState.IsValid == true)
                {
                  
                return RedirectToAction("Index");
                }


                else
                {
                    TempData["Message"] = "Validation Error";
                    return View(ob);
                }
            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View(ob);

            }


            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var Data = await academicyear.GetByIdAsync(Id);
            var data = mapper.Map<AcademicYearVM>(Data);
            return View(data);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(AcademicYearVM obj)
        {
            try
            {
                var data = mapper.Map<AcademicYear>(obj);
                await academicyear.DeleteAsync(data);
                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View(obj);

            }


        }

    }

}

