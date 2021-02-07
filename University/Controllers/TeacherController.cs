using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using service.Main;
using service.Main.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private Teachers _teacher = new Teachers();
        private service.Main.Repository _main = new service.Main.Repository();
        public async Task<IActionResult> remove(int dep, int Id)
        {
            _main.Remove(await _main.GetById<Teacher>(Id));
            return LocalRedirect("/Teacher/data/" + dep);
        }

        public async Task<IActionResult> data(int Id)
        {
            dynamic result = new ExpandoObject();
            result.Id = Id;
            var data = new List<Teacher>();
            var d = (await _teacher.Get(Id)).ToList();
            if (d.Count() != 0)
            {
                data.AddRange(d);
            }
            result.list = data;
            return View(result);
        }

        public IActionResult add(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> add(Teacher teacher)
        {
            await _main.Add(new Teacher
            {
                Name = teacher.Name,
                Surname = teacher.Surname,
                Patronymic = teacher.Patronymic,
                PhoneNumber = teacher.PhoneNumber,
                Email = teacher.Email,
                AcademicDegree = teacher.AcademicDegree,
                AcademicTitle = teacher.AcademicTitle,
                BirthDay = teacher.BirthDay,
                DepartmentId = teacher.DepartmentId,
                Login = teacher.Login,
                Password = teacher.Password,
                Role = teacher.Role
            });
            return LocalRedirect("/Teacher/data/" + teacher.DepartmentId);
        }

        public async Task<IActionResult> edit(int Id)
        {
            ViewBag.obj = await _main.GetById<Teacher>(Id);
            return View();
        }

        public async Task<JsonResult> get(int Id){
            var temp  =await _main.GetById<Teacher>(Id);
            try
            {
                return Json(temp);
            }
            catch (NullReferenceException)
            {
                return Json(404);
            }
        }
        
        [HttpPost]
        public IActionResult edit(Teacher teacher)
        {
            _teacher.Change(teacher.Id, new Teacher
            {
                Name = teacher.Name,
                Surname = teacher.Surname,
                Patronymic = teacher.Patronymic,
                PhoneNumber = teacher.PhoneNumber,
                Email = teacher.Email,
                AcademicDegree = teacher.AcademicDegree,
                AcademicTitle = teacher.AcademicTitle,
                BirthDay = teacher.BirthDay,
                DepartmentId = teacher.DepartmentId,
                Login = teacher.Login,
                Password = teacher.Password,
                Role = teacher.Role
            });
            return LocalRedirect("/Teacher/data/" + teacher.DepartmentId);
        }
    }
}