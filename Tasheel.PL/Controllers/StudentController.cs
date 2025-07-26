using System.Collections.Generic;
using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasheel.BLL.Intrefaces;
using Tasheel.BLL.Models;
using Tasheel.BLL.Repository;
using Tasheel.DAL.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace Tasheel.PL.Controllers
{
    //[Authorize]
    public class StudentController : Controller

    {
        private readonly IStudent student;
        private readonly Inationality  nationality;
        //نعطي علم اني بنستخد اوتو مابر
        private readonly IMapper mapper;

        //تكوين كائن
        public StudentController(IStudent SS , IMapper mapper , Inationality NN )
            {
           this.student = SS;
            this.mapper = mapper;
            this.nationality = NN;
        }
        public async Task<IActionResult> Index()
        {

            var data = await student.GetAsync();
            var result = mapper.Map<IEnumerable<StudentVM>>(data);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)                                           
        {

            var Data = await student.GetByIdAsync(x => x.Id == Id);
            var result = mapper.Map<StudentVM>(Data);
            // تحقق هل الـ ID موجود أم لا
            if (result == null)
            {
                ViewBag.Message = "هذا الـ ID غير موجود في قاعدة البيانات.";

                return View(); // يرجع العرض بدون بيانات
            }

            // إعداد قائمة الجنسيات
            var na = mapper.Map<IEnumerable<NationalityVM>>(await nationality.GetAllAsync());
            ViewBag.NationalityList = new SelectList(na, "Id", "Name", result.NationalityId);


            return View(result);



        }
        [HttpPost]
        public async Task<IActionResult> Delete(StudentVM obj)
        {
            try

            {
                var data = mapper.Map<Student>(obj);

                await student.DeleteAsync(data);
                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View(obj);

            }


            
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var data = await nationality.GetAllAsync();
            var result = mapper.Map<IEnumerable<NationalityVM>>(data);

            ViewBag.NationalityList = new SelectList(result ,"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentVM ob)
        {
             try

            {
                //if (ModelState.IsValid == true)

                //{
                    var data =mapper.Map<Student>(ob);
                    await student.CreateAsync(data);
                    return RedirectToAction("Create","Card", new { studentId = data.Id });
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
            var Data = await student.GetByIdAsync(x=>x.Id==Id);
            var result = mapper.Map<StudentVM>(Data);
            // تحقق هل الـ ID موجود أم لا
            if (result == null)
            {
                ViewBag.Message = "هذا الـ ID غير موجود في قاعدة البيانات.";

                return View(); // يرجع العرض بدون بيانات
            }

            // إعداد قائمة الجنسيات
            var na = mapper.Map<IEnumerable<NationalityVM>>(await nationality.GetAllAsync());

            //ViewBag.NationalityList = new SelectList("na", "Id", "Name", "result.NationalityId");
            ViewBag.NationalityList = new SelectList(na, "Id", "Name", result.NationalityId);


            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Edeit(StudentVM ob)

        {
            try

            {
                //if (ModelState.IsValid == true)
                //{
                    var data = mapper.Map<Student>(ob);
                await student.EdeiteAsync(data);
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
            var data = await student.GetByIdAsync(x => x.Id == id);
            var result = mapper.Map<StudentVM>(data);
            return View(result);
        }








    }
}
