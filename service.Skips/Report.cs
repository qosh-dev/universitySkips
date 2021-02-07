using Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using service.Main.Extention;
using service.Main.Models;
using service.Skips.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.Skips
{
    public class Report
    {
        private string[] headersList = new string[]{
                "Все пропуски",
                "По уважительной",
                "По неуважительной"
                };
        private service.Skips.Repository _skip;
        private Get _get;
        private service.Main.Repository _main;
        
        public Report()
        {
            _main = new service.Main.Repository();
            _skip = new service.Skips.Repository();
            _get = new Get();
        }

        public void GetViewSkip(int Id, ref List<ViewSkip> result)
        {
            Student student = _main.GetById<Student>(Id).Result;
            var temObj = _get.SkipsShort(student.Id).Result;
            for (int i = 0; i < temObj.Count(); i++)
            {
                result.Add(new ViewSkip
                {
                    id = student.Id,
                    name = student.FullName,
                    Count = temObj[i].Count,
                    Month = temObj[i].Month,
                    SReasonCount = temObj[i].SReasonCount,
                    Total = temObj[i].Count - temObj[i].SReasonCount,
                    EduYear = temObj[i].EduYear,
                    Semester = temObj[i].Semester,
                    BB = student.BB == null ? "Не указано" : student.BB
                });
            }
        }

        public async Task<List<ViewSkip>> BySemestry(int groupId, int EduYear = 0, int Semester = 0)
        {
            var result = new List<ViewSkip>();
            Group group = await _main.GetById<Group>(groupId);
            Student[] students = (await _main.Where<Student>(e => e.GroupId == group.Id))
                                             .OrderBy(e => e.Id)
                                             .OrderBy(e => e.Surname)
                                             .ToArray();
            for (int j = 0; j < students.Count(); j++)
            {
                GetViewSkip(students[j].Id, ref result);
            }
            if (EduYear != 0 && Semester != 0)
            {
                return result.Where(e => e.EduYear == EduYear &&
                                         e.Semester == Semester)
                             .ToList();
            }
            else
            {
                return result;
            }
        }

        public List<MonthReport> GetMonthReport(int course, List<ViewSkip> result)
        {
            var temp = result.Paginate(course,
                                       result.Select(e => e.Month).Distinct().Count())
                                 .Select(e => new MonthReport
                                 {
                                     count = e.Count,
                                     sreason = e.SReasonCount,
                                     total = e.Total
                                 }).ToList();
            if (temp.Count() == 0)
            {
                return new List<MonthReport>();
            }
            temp.Add(
                new MonthReport
                {
                    count = temp.Select(e => e.count).Sum(),
                    sreason = temp.Select(e => e.sreason).Sum(),
                    total = temp.Select(e => e.total).Sum()
                }
            );
            return temp;
        }

        public async Task<ReportToWorkSheet> ReportToWorkSheet(int groupId, int EduYear, int semester, int fromCount)
        {
            var result = (await this.BySemestry(groupId, EduYear, semester)).ToList();

            int[] idList = result.Select(e => e.id).ToArray();
            var month = result.Select(e => e.Month).Distinct().ToList();
            int count = result.Count() / month.Count();
            var ret = new List<List<MonthReport>>();
            var studentNames = result.Select(e => e.name).ToList();
            var tempStudent = new List<string>();
            for (int i = 0; i < studentNames.Count(); i += month.Count())
            {
                tempStudent.Add(studentNames[i]);
            }
            studentNames = tempStudent;
            var BBList = result.Select(e => e.BB).ToList();
            var tempBB = new List<string>();
            for (int i = 0; i < BBList.Count(); i += month.Count())
            {
                tempBB.Add(BBList[i]);
            }
            BBList = tempBB;


            for (int course = 1; course < count + 1; course++)
            {
                ret.Add(GetMonthReport(course, result));
            }
            month.Add("Итог");
            if (fromCount != 0)
            {
                var names = new List<string>();
                var bb = new List<string>();
                var d = new List<List<MonthReport>>();
                for (int i = 0; i < ret.Count(); i++)
                {
                    if (ret[i].Last().total >= fromCount)
                    {
                        d.Add(ret[i]);

                        names.Add(result[i * (month.Count() - 1)].name);
                        bb.Add(result[i * (month.Count() - 1)].BB);
                    }
                }
                ret = d.Distinct().ToList();
                BBList = bb.ToList();
                studentNames = names.ToList();
            }

            return new ReportToWorkSheet
            {
                headersList = headersList,
                data = ret,
                month = month.ToArray(),
                names = studentNames,
                bblist = BBList
            };
        }

        public async Task<FileContentResult> BuildComplexFile(ControllerBase obj, int depId, int eduYear, int semester, int fromCount)
        {
            var groups = await _main.Where<Group>(e => e.DepartmentId == depId);
            return obj.Excel(e =>
            {
                foreach (var el in groups)
                {
                    try
                    {
                        var result = this.ReportToWorkSheet(el.Id, eduYear, semester, fromCount).Result;
                        int step = result.headersList.Count();
                        var workSheet = e.addWorkSheet($"{el.Name}_{el.EduFrom}")
                                        .AddMergedHeaders(result.month, step: step, colomn: 2)
                                        .AddLoop(result.names, row: 3)
                                        .AddHeaders(result.headersList, row: 2, colomn: 2);
                        int startColomn = 2;
                        int row = 3;

                        for (int i = 0; i < result.month.Count(); i++)
                        {
                            workSheet.AddHeaders(result.headersList, row: 2, colomn: startColomn);
                            startColomn += step;
                        }

                        for (int i = 0; i < result.data.Count; i++)
                        {
                            workSheet.AddLoopVertical(result.data[i], 2, row);
                            row++;
                        }
                        workSheet[1, 1, 2, 1].Merge = true;
                        workSheet[1, 1, 2, 1].Value = "Ф. И. О.";
                        workSheet[1, 1, 2, 1].Style.Font.Bold = true;
                        workSheet[1, 1, 2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        if (semester == 1)
                        {
                            workSheet[1, 17, 2, 17].Merge = true;
                            workSheet[1, 17, 2, 17].Value = "Болельщик";
                            workSheet[1, 17, 2, 17].Style.Font.Bold = true;
                            workSheet[1, 17, 2, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            workSheet[1, 17, 2, 17].AutoFitColumns();
                            workSheet.AddLoop(result.bblist, row: 3, colomn: 17);
                        }
                        else
                        {
                            workSheet[1, 20, 2, 20].Merge = true;
                            workSheet[1, 20, 2, 20].Value = "Болельщик";
                            workSheet[1, 20, 2, 20].Style.Font.Bold = true;
                            workSheet[1, 20, 2, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            workSheet[1, 20, 2, 20].AutoFitColumns();
                            workSheet.AddLoop(result.bblist, row: 3, colomn: 20);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }

            }, DateTime.Now.Year + "_Report");
        }
        
        public async Task<FileContentResult> BuildFile(ControllerBase obj, int groupId, int eduYear, int semester, int fromCount)
        {
            ReportToWorkSheet result = await this.ReportToWorkSheet(groupId, eduYear, semester, fromCount);
            Group group = await _main.GetById<Group>(groupId);
            return obj.Excel(e =>
            {
                int step = result.headersList.Count();
                var first = e.addWorkSheet($"{group.Name}_{group.EduFrom}")
                                .AddMergedHeaders(result.month, step: step, colomn: 2)
                                .AddLoop(result.names, row: 3)
                                .AddHeaders(result.headersList, row: 2, colomn: 2);
                int startColomn = 2;
                int row = 3;

                for (int i = 0; i < result.month.Count(); i++)
                {
                    first.AddHeaders(result.headersList, row: 2, colomn: startColomn);
                    startColomn += step;
                }

                for (int i = 0; i < result.data.Count; i++)
                {
                    first.AddLoopVertical(result.data[i], 2, row);
                    row++;
                }
                first[1, 1, 2, 1].Merge = true;
                first[1, 1, 2, 1].Value = "Ф. И. О.";
                first[1, 1, 2, 1].Style.Font.Bold = true;
                first[1, 1, 2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                if (semester == 1)
                {
                    first[1, 17, 2, 17].Merge = true;
                    first[1, 17, 2, 17].Value = "Болельщик";
                    first[1, 17, 2, 17].Style.Font.Bold = true;
                    first[1, 17, 2, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    first[1, 17, 2, 17].AutoFitColumns();
                    first.AddLoop(result.bblist, row: 3, colomn: 17);
                }
                else
                {
                    first[1, 20, 2, 20].Merge = true;
                    first[1, 20, 2, 20].Value = "Болельщик";
                    first[1, 20, 2, 20].Style.Font.Bold = true;
                    first[1, 20, 2, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    first[1, 20, 2, 20].AutoFitColumns();
                    first.AddLoop(result.bblist, row: 3, colomn: 20);
                }
            }, $"{group.Name}_{group.EduFrom}_Course={eduYear}_semester={semester}");
        }

        public async Task<FileContentResult> getTemplate(ControllerBase obj, int groupId)
        {
            Group group = await _main.GetById<Group>(groupId);
            Student[] students = (await _main.Where<Student>(e => e.GroupId == groupId))
                                             .OrderBy(e => e.Id)
                                             .OrderBy(e => e.Surname)
                                             .ToArray();
            var names = students.Select(e => e.FullName).ToList();
            return obj.Excel(e =>
            {
                var worksheet = e.addWorkSheet("templateFor" + group.Name)
                                 .AddHeaders(headersList, 2)
                                 .AddLoop(names);
                worksheet[1, 1].Value = "Ф. И. О.";
                worksheet[1, 1].Style.Font.Bold = true;
                worksheet[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; ;
            }, "Template");
        }
    }
}