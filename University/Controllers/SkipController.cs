using Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service.Main.Models;
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
    public class SkipController : Controller
    {
        #region references

        private service.Main.Repository _main = new service.Main.Repository();
        private Report _report = new Report();
        private Set _setSkips = new Set();
        private Get _getSkips = new Get();

        private static IWebHostEnvironment _appEnvironment;
        public SkipController(IWebHostEnvironment appEnvironment) => _appEnvironment = appEnvironment;
        #endregion
        public async Task<IActionResult> Report(int Id, int eduYear, int semester, int fromCount = 0)
        {
            try
            {
                return await _report.BuildFile(this, Id, eduYear, semester, fromCount);
            }
            catch (System.Exception)
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> ReportAllOf(int eduYear, int semester, int depId = 1, int fromCount = 0)
        {
            return await _report.BuildComplexFile(this, depId, eduYear, semester, fromCount);
        }


        public async Task<IActionResult> getTemplate(int Id) => await _report.getTemplate(this, Id);

        [HttpPost]
        public async Task<IActionResult> setSkips(IFormFile file, int groupId, int eduYear, int semester, string month)
        {
            try
            {
                Group group = await _main.GetById<Group>(groupId);
                string path = await _appEnvironment.AddFile(file, "Excel", "Skips");
                var excelFile = new Excel.Open(path);
                var data = excelFile.toList<AddSkips>();

                _setSkips.setSkip(data, month, eduYear, semester, groupId);
                return Json("Данные сохранены");
            }

            catch (System.Exception)
            {
                return Json("Непредвиденная ошибка");
            }
        }

        [HttpPost]
        public async Task<IActionResult> setSReason(int Id, string month, int count, IFormFile files)
        {
            Student student = await _main.GetById<Student>(Id);
            try
            {
                string path = await _appEnvironment.AddFile(files, "Img", "SReasons");
                _setSkips.setSReason(path, Id, month, count);
                return Json("Данные сохранены");
            }
            catch (NullReferenceException)
            {
                return Json("Непредвиденная ошибка");
            }
        }

        // Report all bad guys
        public async Task<IActionResult> bad()
        {
            Group[] groups = await _main.Get<Group>();
            List<ReportToWorkSheet> reportToWorkSheets16 = new List<ReportToWorkSheet>();
            var id16 = new List<Group>();
            List<ReportToWorkSheet> reportToWorkSheets35 = new List<ReportToWorkSheet>();
            var id35 = new List<Group>();
            foreach (var group in groups)
            {
                try
                {
                    var temp = await _report.ReportToWorkSheet(group.Id, group.Course, lib.Methods.GetSemestry(), 16);
                    if (temp.data.Count() != 0)
                    {
                        reportToWorkSheets16.Add(temp);
                        id16.Add(group);
                    }
                }
                catch (DivideByZeroException)
                {
                    continue;
                }
            }
            foreach (var group in groups)
            {
                try
                {
                    var temp = await _report.ReportToWorkSheet(group.Id, group.Course, lib.Methods.GetSemestry(), 35);
                    if (temp.data.Count() != 0)
                    {
                        reportToWorkSheets35.Add(temp);
                        id35.Add(group);
                    }
                }
                catch (DivideByZeroException)
                {
                    continue;
                }
            }
            dynamic result = new ExpandoObject();

            dynamic r16 = new ExpandoObject();
            r16.data = reportToWorkSheets16;
            r16.id = id16;

            dynamic r35 = new ExpandoObject();
            r35.data = reportToWorkSheets35;
            r35.id = id35;

            result.R16 = r16;
            result.R35 = r35;

            return View(result);
        }

        public async Task<JsonResult> blackList(int dep)
        {
            Group[] groups = await _main.Get<Group>();
            List<ReportToWorkSheet> data = new List<ReportToWorkSheet>();
            var idList = new List<Group>();

            foreach (var group in groups)
            {
                try
                {
                    var temp = await _report.ReportToWorkSheet(group.Id, group.Course, lib.Methods.GetSemestry(), 35);
                    if (temp.data.Count() != 0)
                    {
                        data.Add(temp);
                        idList.Add(group);
                    }
                }
                catch (DivideByZeroException)
                {
                    continue;
                }
            }
            return Json(new { data, idList });
        }

        public async Task<JsonResult> yellowList(int dep)
        {
            Group[] groups = await _main.Get<Group>();
            List<ReportToWorkSheet> data = new List<ReportToWorkSheet>();
            var idList = new List<Group>();

            foreach (var group in groups)
            {
                try
                {
                    var temp = await _report.ReportToWorkSheet(group.Id, group.Course, lib.Methods.GetSemestry(), 16);
                    if (temp.data.Count() != 0)
                    {
                        data.Add(temp);
                        idList.Add(group);
                    }
                }
                catch (DivideByZeroException)
                {
                    continue;
                }
            }
            return Json(new { data, idList });
        }
    
    
        public async Task<IActionResult> getrefer(int grId,int course, int semester,int Id ){
            try
            {
                var result = await _getSkips.GetRefer(grId,course,semester,Id);
                return View(result);
            }
            catch (System.Exception)
            {
                return View();                
            }
        }
    
    }
}