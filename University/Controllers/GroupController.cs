using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using service.Main;
using service.Main.Models;
using service.Main.ViewModels;
using service.Skips;
using service.Skips.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        #region references
        private service.Main.Repository _main = new service.Main.Repository();
        private service.Skips.Repository _skip = new service.Skips.Repository();
        private Groups _group = new Groups();
        private Report _report = new Report();
        #endregion


        public async Task<IActionResult> groupByDep(int Id)
        {
            dynamic result = new ExpandoObject();
            result.groups = new List<ViewGroup>();
            result.Department = new Department();
            result.groups = (await _group.GetGroups(Id))
                                         .Where(e => e.IsFinished)
                                         .ToList();
            result.Department = await _main.GetById<Department>(Id);
            return View(result);
        }

        public async Task<IActionResult> emptyGroup(int Id) => View(await _group.GetGroupDesc(Id));

        public async Task<IActionResult> descSorted(int id, int type)
        {
            dynamic result = new ExpandoObject();

            Group group = await _main.GetById<Group>(id);

            ReportToWorkSheet data = await _report.ReportToWorkSheet(id, group.Course, lib.Methods.GetSemestry(), type);


            List<int> idList = new List<int>();
            List<MonthReport> monthReports = data.data.Select(e => e.Last()).ToList();
            for (int i = 0; i < data.names.Count(); i++)
            {
                Student student = await _main.First<Student>(e => e.FullName == data.names[i]);
                idList.Add(student.Id);
            }
            result.desc = await _group.GetGroupDesc(id);
            result.Skips = monthReports;
            result.IdList = idList;
            result.Names = data.names;
            result.BB = data.bblist;
            result.type = type;
            return View(result);
        }
        public async Task<IActionResult> desc(int Id = 2, int EduYear = 0, int semester = 0)
        {
            try
            {
                dynamic result = new ExpandoObject();

                Group group = await _main.GetById<Group>(Id);

                semester = semester == 0 ? lib.Methods.GetSemestry() : semester;
                EduYear = EduYear == 0 ? group.Course : EduYear;

                ReportToWorkSheet data = await _report.ReportToWorkSheet(Id, EduYear, semester, 0);


                List<int> idList = new List<int>();
                List<MonthReport> monthReports = data.data.Select(e => e.Last()).ToList();
                for (int i = 0; i < data.names.Count(); i++)
                {
                    Student student = await _main.First<Student>(e => e.FullName == data.names[i]);
                    idList.Add(student.Id);
                }
                result.elder = await _main.GetById<Student>(group.HeadManId);
                result.desc = await _group.GetGroupDesc(Id);
                result.Skips = monthReports;
                result.IdList = idList;
                result.Names = data.names;
                result.BB = data.bblist;
                result.EduYear = EduYear;
                result.semester = semester;
                return View(result);
            }
            catch (Exception)
            {
                return LocalRedirect("/Group/emptyGroup/" + Id);
            }
        }



        [AllowAnonymous]
        public async Task<IActionResult> showSS(int Id = 2, int EduYear = 0, int semester = 0)
        {
            try
            {
                dynamic result = new ExpandoObject();

                Group group = await _main.GetById<Group>(Id);

                semester = semester == 0 ? lib.Methods.GetSemestry() : semester;
                EduYear = EduYear == 0 ? group.Course : EduYear;

                ReportToWorkSheet data = await _report.ReportToWorkSheet(Id, EduYear, semester, 0);


                List<int> idList = new List<int>();
                List<MonthReport> monthReports = data.data.Select(e => e.Last()).ToList();
                for (int i = 0; i < data.names.Count(); i++)
                {
                    Student student = await _main.First<Student>(e => e.FullName == data.names[i]);
                    idList.Add(student.Id);
                }
                result.Skips = monthReports;
                result.IdList = idList;
                result.Names = data.names;
                result.GroupName = group.Name;

                return View(result);
            }
            catch (Exception)
            {
                return LocalRedirect("/Group/emptyGroup/" + Id);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddGroup(int Id)
        {
            try
            {
                dynamic result = new ExpandoObject();
                ViewBag.Department = await _main.GetById<Department>(Id);
                ViewBag.EduLevel = new string[] {
                    "Бакалаврият",
                    "Магистратура",
                    "Аспирантура"
                };
                ViewBag.Specialities = (await _main.Get<Speciality>()).Where(e => e.DepartmentId == Id).Select(e => e.Name).ToArray();
                ViewBag.TeachersKey = (await _main.Get<Teacher>()).Select(e => e.Id).ToArray();
                ViewBag.Teachers = (await _main.Get<Teacher>()).Select(e => e.FullName).ToArray();
                return View();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<dynamic> AddGroup(AddGroupForm obj)
        {
            var (isRegistered, id) = await _group.Add(
                    new Group
                    {
                        CuratorId = obj.CuratorId,
                        DepartmentId = obj.Id,
                        EduFrom = obj.EduFrom,
                        EduLevel = obj.EduLevel,
                        HeadManId = 0,
                        Key = obj.Name,
                        Notes = obj.Note,
                        StudyForm = obj.StudyForm,
                        Speciality = obj.Speciality
                    }
                );
            if (isRegistered)
            {
                return LocalRedirect("/Group/desc/" + id);
            }
            else
            {
                return "Непредвиденная ошибка : вызванная скорее всего тем что группа уже существует или тем что вы некоректно ввели данные";
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            Group group = await _main.GetById<Group>(Id);
            Department department = await _main.First<Department>(e => e.Id == group.DepartmentId);
            Teacher headman = await _main.GetById<Teacher>(group.CuratorId);

            try
            {
                var students = await _main.Where<Student>(e => e.GroupId == group.Id);
                ViewBag.Students = students;
            }
            catch (System.Exception)
            {
                ViewBag.Students = new Student[0];
            }
            if (group.Id != 0)
            {
                ViewBag.HeadMan = await _main.GetById<Student>(group.HeadManId);
            }

            ViewBag.Department = department;
            var EduLevel = new List<string>(){
                "Бакалаврият",
                "Магистратура",
                "Аспирантура"
            };
            EduLevel.Remove(group.EduLevel);

            var Teachers = (await _main.Get<Teacher>())
                                       .Select(e => e.FullName)
                                       .ToList();
            var TeachersKey = (await _main.Get<Teacher>())
                                           .Select(e => e.Id)
                                           .ToList();

            var curator = await _main.GetById<Teacher>(group.CuratorId);
            ViewBag.GroupTeacher = curator != null ? curator : new Teacher();
            try
            {
                TeachersKey.Remove(group.HeadManId);
                ViewBag.TeachersKey = TeachersKey;

                if (headman != null)
                {
                    Teachers.Remove(headman.FullName);
                }
                ViewBag.Teachers = Teachers;
            }
            catch (NullReferenceException)
            {
                ViewBag.GroupTeacher = new Teacher().Id = 0;
            }

            var Spec = (await _main.Get<Speciality>())
                                   .Where(e => e.DepartmentId == department.Id)
                                   .Select(e => e.Name)
                                   .ToList();
            Spec.Remove(group.Speciality);
            ViewBag.EduLevel = EduLevel;
            ViewBag.Specialities = Spec;
            ViewBag.Group = group;
            return View();
        }

        [HttpPost]
        public dynamic Edit(EditGroup obj, int IdToEdit)
        {
            try
            {
                Group temp = new Group
                {
                    Key = obj.Name,
                    HeadManId = obj.HeadmanId,
                    CuratorId = obj.CuratorId,
                    StudyForm = obj.StudyForm,
                    Notes = obj.Note,
                    EduFrom = obj.EduFrom,
                    Speciality = obj.Speciality,
                    DepartmentId = obj.Id,
                    EduLevel = obj.EduLevel,
                };

                _main.Change(IdToEdit, temp);
                return LocalRedirect("/Group/desc/" + IdToEdit);
            }
            catch (System.Exception)
            {
                return "Непредвиденная ошибка";
            }
        }

        public async Task<IActionResult> Remove(int Id)
        {
            _skip.RemoveFromGroup(Id);
            Group group = await _main.GetById<Group>(Id);
            bool isRemoved = await _main.RemoveGroup(group);
            if (isRemoved)
            {
                return LocalRedirect("/Home/Index");
            }
            else
            {
                return Json("Непредвиденная ошибка");
            }
        }

        public async Task<JsonResult> Get()
        {
            dynamic result = new ExpandoObject();
            try
            {
                var temp = (await _group.GetGroups(1)).Select(e => new
                {
                    id = e.Id,
                    name = e.Name,
                    course = DateTime.Now.Year - e.EduStart + 1,
                    eduduration = e.EduDuration,
                    udustart = e.EduStart,
                    isfinished = e.IsFinished
                }).ToArray();
                if (temp.Count() == 0)
                {
                    result.data = "Данные не найдены или непредвиденная ошибка";
                    result.key = 404;
                    return Json(result);
                }
                result.data = temp.OrderByDescending(e => e.isfinished);
                result.key = 200;
            }
            catch (System.Exception)
            {
                result.key = 404;
                result.data = "Данные не найдены или непредвиденная ошибка";
            }
            return Json(result);
        }
        public async Task<IActionResult> getById(int id) => Json(await _main.GetById<Group>(id));
    }
}