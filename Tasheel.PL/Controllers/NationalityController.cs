using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasheel.BLL.Intrefaces;
using Tasheel.BLL.Models;
using Tasheel.BLL.Repository;
using Tasheel.DAL.Entities;

namespace Tasheel.PL.Controllers
{
    //[Authorize]
    public class NationalityController : Controller
    {
        private readonly Inationality nationality;

        //نعطي علم اني بنستخد اوتو مابر
        private readonly IMapper mapper;
        public NationalityController(Inationality NA , IMapper mapper)
        {
            this.nationality = NA;
            this.mapper = mapper;
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var data = await nationality.GetAllAsync();
            var result = mapper.Map<IEnumerable<NationalityVM>>(data);
            return View(result);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
       
        }
     
        [HttpPost]
        public async Task<IActionResult> Create(NationalityVM ob)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                // التحقق من وجود الجنسية مسبقًا
                var existingYear = await nationality.GetByNameAsync(ob.Name);
                if (existingYear != null)
                {
                    TempData["ErrorMsg"] = "هذه الجنسية موجودة بالفعل ولا يمكن اضافتها مرة اخرى.";
                    return View(ob);
                }

                //  تحويل النموذج إلى الكيان باستخدام AutoMapper
                
            
                var details = mapper.Map<Nationality>(ob);
                await nationality.CreateAsync(details);

                TempData["SuccessMsg"] = " تم إضافة الجنسية بنجاح.";
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
                return View(ob);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edeit(int Id)
        {
            var Data = await nationality.GetByIdAsync(Id);

            return View(Data);

        }
        [HttpPost]
        public async Task<IActionResult> Edeit(NationalityVM ob)
        {
            try

            {
                //if (ModelState.IsValid == true)
                //{
                    var data = mapper.Map<Nationality>(ob);
                    await nationality.EdeiteAsync(data);
                return RedirectToAction("Index");
                //}



                //else
                //{
                //    TempData["Message"] = "Validation Error";
                //    return View(ob);
                //}
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
           
            var Data = await nationality.GetByIdAsync(Id);
              var data = mapper.Map<NationalityVM>(Data);
            return View(data);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(NationalityVM obj)
        {
            try

            {
                var data = mapper.Map<Nationality>(obj);
                await nationality.DeleteAsync(data);
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
