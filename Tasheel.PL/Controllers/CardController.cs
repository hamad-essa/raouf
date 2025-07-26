using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasheel.BLL.Intrefaces;
using Tasheel.BLL.Models;
using Tasheel.DAL.Entities;

namespace Tasheel.PL.Controllers
{
    [Authorize(Roles = "Admin,Parent")]
    public class CardController : Controller
    {
        private readonly ICard card;
        private readonly Iacademicyear academicyear;
        private readonly IStudent student;
        //نعطي علم اني بنستخد اوتو مابر
        private readonly IMapper mapper;

        //تكوين كائن
        public CardController(ICard CC, IMapper mapper, Iacademicyear AA, IStudent SS)
        {
            this.card = CC;
            this.mapper = mapper;
            this.academicyear = AA;
            this.student = SS;
        }

        public async Task<IActionResult> Index()
        {

            var data = await card.GetAsync();
            var result = mapper.Map<IEnumerable<CardVM>>(data);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {

            var Data = await card.GetByIdAsync(x => x.Id == Id);
            var result = mapper.Map<CardVM>(Data);
            // تحقق هل الـ ID موجود أم لا
            if (result == null)
            {
                ViewBag.Message = "هذا الـ ID غير موجود في قاعدة البيانات.";

                return View(); // يرجع العرض بدون بيانات
            }

            // إعداد قائمة الجنسيات
            var na = mapper.Map<IEnumerable<AcademicYearVM>>(await academicyear.GetAllAsync());
            ViewBag.AcademicYearList = new SelectList(na, "Id", "AcademicClass", result.AcademicYearId);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CardVM obj)
        {
            try

            {
                var data = mapper.Map<Card>(obj);

                await card.DeleteAsync(data);
                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View(obj);

            }
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? studentId)
        {
            var data = await academicyear.GetAllAsync();
            var result = mapper.Map<IEnumerable<AcademicYearVM>>(data);

            ViewBag.academicyearList = new SelectList(result, "Id", "Year");

            var students = await student.GetAsync();
            ViewBag.StudentList = new SelectList(students, "Id", "FullName", studentId);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CardVM ob)
        {
            try

            {
                //if (ModelState.IsValid == true)

                //{


                var data = mapper.Map<Card>(ob);
                await card.CreateAsync(data);
                return RedirectToAction("Index");
                //}

                //else
                //{
                //    TempData["Message"] = "Validation Error";
                //    return View(ob);
                //}

            }
            //catch (Exception ex)
            //{
            //    TempData["Message"] = ex.Message;
            //    return View(ob);

            //}
            catch (Exception ex)
            {
                TempData["Message"] = ex.InnerException?.Message ?? ex.Message;
                return View(ob);
            }




        }

        [HttpGet]
        public async Task<IActionResult> Edeit(int Id)
        {
            var Data = await card.GetByIdAsync(x => x.Id == Id);
            var result = mapper.Map<CardVM>(Data);
            // تحقق هل الـ ID موجود أم لا
            if (result == null)
            {
                ViewBag.Message = "هذا الـ ID غير موجود في قاعدة البيانات.";

                return View(); // يرجع العرض بدون بيانات
            }

            // إعداد قائمة الجنسيات
            var na = mapper.Map<IEnumerable<AcademicYearVM>>(await academicyear.GetAllAsync());
            ViewBag.AcademicYearList = new SelectList(na, "Id", "AcademicClass", result.AcademicYearId);


            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Edeit(CardVM ob)

        {
            try

            {
                //if (ModelState.IsValid == true)
                //{
                var data = mapper.Map<Card>(ob);
                await card.EdeiteAsync(data);
                return RedirectToAction("Index");
                //}

                //else
                //{
                //TempData["Message"] = "Validation Error";
                //return View(ob);
                //}

            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View(ob);

            }
        }
        public async Task<IActionResult> Details(int id)
        {
            var data = await card.GetByIdAsync(x => x.Id == id);
            var result = mapper.Map<CardVM>(data);
            return View(result);
        }

    }
}
