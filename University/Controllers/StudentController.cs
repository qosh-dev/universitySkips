using Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service.Main;
using service.Main.Models;
using service.Main.ViewModels;
using service.Skips;
using service.Skips.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace University.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        #region references
        private service.Main.Repository _main = new service.Main.Repository();
        private service.Skips.Repository _skip = new service.Skips.Repository();
        private Groups _group = new Groups();
        private Students _student = new Students();
        private Report _report = new Report();
        private Set _setSkips = new Set();
        private Get _getSkips = new Get();

        private static IWebHostEnvironment _appEnvironment;
        public StudentController(IWebHostEnvironment appEnvironment) => _appEnvironment = appEnvironment;
        #endregion

        [HttpGet]
        public async Task<IActionResult> list(int Id)
        {
            dynamic result = new ExpandoObject();
            result.list = await _main.Where<Student>(e => e.GroupId == Id);
            result.group = await _group.GetGroupDesc(Id);
            return View(result);
        }
        [HttpGet]
        public IActionResult AddStudent(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add(AddStudentForm obj, IFormFile file = null)
        {
            Group group = await _main.GetById<Group>(obj.GroupId);
            int Id = await _student.addStudent(
                new Student
                    {
                        Address = obj.Address,
                        Birthday = obj.Birthday,
                        Contract = obj.Contract,
                        Email = obj.Email,
                        GroupId = group.Id,
                        Img = obj.Img,
                        Note = obj.Note,
                        Patronymic = obj.Patronymic,
                        PhoneNumber = obj.PhoneNumber,
                        RecordBookNumber = obj.RecordBookNumber,
                        Surname = obj.Surname,
                        Name = obj.Name,
                        BB = obj.BB
                    }
                );
            _setSkips.init(Id);
            if (file != null)
            {
                string result = await _appEnvironment.AddFile(file, "Img", "Students");
            }
            return LocalRedirect("/Group/desc/" + group.Id);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentRange(IFormFile file, int groupId)
        {
            string result = await _appEnvironment.AddFile(file, "Excel", "Students");
            var excel = new Excel.Open(result);
            var tempStudents = excel.toList<AddStudentExcel>(1);
            Group group = await _main.GetById<Group>(groupId);
            foreach (var el in tempStudents)
            {
                int Id = await _student.addStudent(
                    new Student
                    {
                        Address = el.Address,
                        Birthday = DateTime.Parse(el.Birthday),
                        Contract = el.Contract == 1 ? true : false,
                        Email = el.Email,
                        GroupId = group.Id,
                        Img = "Картинка отсутствует",
                        Note = el.Note,
                        Patronymic = el.Patronymic,
                        PhoneNumber = el.PhoneNumber,
                        RecordBookNumber = el.RecordBookNumber,
                        Surname = el.Surname,
                        Name = el.Name
                    }
                );
                if (Id != 0)
                {
                    _setSkips.init(Id);
                }
            }
            return LocalRedirect("/Group/desc/" + group.Id);
        }
        public async Task<IActionResult> remove(int Id)
        {
            Student student = await _main.GetById<Student>(Id);
            int grId = student.GroupId;
            _skip.RemoveStudentSkips(Id);
            _main.Remove(await _main.GetById<Student>(Id));
            return LocalRedirect("/Group/desc/" + grId);
        }

        public async Task<IActionResult> edit(int Id)
        {
            return View(await _main.GetById<Student>(Id));
        }

        [HttpPost]
        public IActionResult edit(Student obj)
        {
            _main.Change(obj);
            return LocalRedirect("/Group/desc/" + obj.GroupId);
        }

        public IActionResult template() => _student.template(this);


        public async Task<IActionResult> desc(int Id)
        {
            var student = await _student.StudentDesc(Id);
            List<ViewSkip> skips = new List<ViewSkip>();
            _report.GetViewSkip(Id, ref skips);
            var retSkips = new List<List<MonthReport>>();
            for (int i = 0; i < student.EduTo - student.EduFrom; i++)
            {
                int course = i + 1;
                retSkips.Add(_report.GetMonthReport(course, skips));
            }
            dynamic result = new ExpandoObject();
            result.desc = student;
            result.skips = retSkips;
            return View(result);
        }

        [AllowAnonymous]
        public async Task<IActionResult> showSS(int Id)
        {
            var student = await _student.StudentDesc(Id);
            List<ViewSkip> skips = new List<ViewSkip>();
            _report.GetViewSkip(Id, ref skips);
            var retSkips = new List<List<MonthReport>>();
            for (int i = 0; i < student.EduTo - student.EduFrom; i++)
            {
                retSkips.Add(_report.GetMonthReport(i + 1, skips));
            }
            dynamic result = new ExpandoObject();
            result.skips = retSkips;

            return View(result);
        }
        public JsonResult getSkipsOf(int Id, int course)
        {
            List<ViewSkip> skips = new List<ViewSkip>();
            _report.GetViewSkip(Id, ref skips);
            return Json(_report.GetMonthReport(course, skips));
        }
    }
}