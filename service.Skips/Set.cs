using service.Main.Models;
using service.Skips.Context;
using service.Skips.Models;
using service.Skips.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace service.Skips
{
    public class Set
    {
        private Main.Repository _main = new Main.Repository();
        private Skips.Repository _skip = new Skips.Repository();

        public async void init(int studentId)
        {
            Student student = await _main.GetById<Student>(studentId);
            Group group = await _main.GetById<Group>(student.GroupId);
            string[] firstSemestry = new string[] { "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            string[] secondSemestry = new string[] { "Февраль", "Март", "Апрель", "Май", "Июнь" };

            for (int i = 1; i <= group.EduDuration; i++)
            {
                for (int m = 0; m < firstSemestry.Count(); m++)
                {
                    Models.Report[] temp = await _skip.Where<Models.Report>(e => e.StudentId == studentId &&
                                                                                 e.EduYear == i &&
                                                                                 e.Semester == 1 &&
                                                                                 e.Month == firstSemestry[m]);
                    if (!temp.Any())
                    {
                        _skip.Add(
                            new Models.Report
                            {
                                StudentId = studentId,
                                Semester = 1,
                                EduYear = i,
                                Count = 0,
                                Month = firstSemestry[m]
                            }
                            );
                    }
                    else
                    {
                        continue;
                    }
                }
                for (int m = 0; m < secondSemestry.Count(); m++)
                {
                    Models.Report[] temp2 = await _skip.Where<Models.Report>(e => e.StudentId == studentId &&
                                                           e.EduYear == i &&
                                                           e.Semester == 2 &&
                                                           e.Month == secondSemestry[m]);
                    if (!temp2.Any())
                    {
                        _skip.Add(
                            new Models.Report
                            {
                                StudentId = studentId,
                                Semester = 2,
                                EduYear = i,
                                Count = 0,
                                Month = secondSemestry[m]
                            }
                        );
                    }
                    else
                    {
                        continue;
                    }
                }
            }

        }

        public async void setSkip(List<AddSkips> data, string month, int eduYear, int semester, int groupId)
        {
            Student[] students = (await _main.Where<Student>(e => e.GroupId == groupId)).OrderBy(e => e.Surname).ToArray();
            using SkipContext _db = new SkipContext();
            for (int i = 0; i < students.Count(); i++)
            {
                var report = _db.DbSet<Models.Report>()
                                .First(e => e.StudentId == students[i].Id &&
                                            e.EduYear == eduYear &&
                                            e.Semester == semester &&
                                            e.Month == month);

                report.Count += data[i].Count;
                _skip.Add(new SReason
                {
                    Count = data[i].SReason,
                    Date = DateTime.Now,
                    Img = "",
                    Skip_Id = report.Id
                });
                await _db.SaveChangesAsync();
            }
        }



        public async void setSReason(string path, int studentId, string month, int count)
        {
            Student student = await _main.GetById<Student>(studentId);
            Group group = await _main.GetById<Group>(student.GroupId);
            using SkipContext _db = new SkipContext();
            Models.Report value = _db.DbSet<Models.Report>()
                                     .First(e =>
                                            e.EduYear == group.Course &&
                                            e.Month == month &&
                                            e.StudentId == studentId);
            _skip.Add(
                new SReason
                {
                    Count = count,
                    Date = DateTime.Now,
                    Img = path,
                    Skip_Id = value.Id
                }
            );
        }
    }
}
