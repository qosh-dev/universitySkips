using service.Main.Models;
using service.Skips.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.Skips
{
    public class Get
    {
        private Main.Repository _main = new Main.Repository();
        private Skips.Repository _skip = new Skips.Repository();
        // public async Task<List<ViewSkipShort>> SkipsFull(int studentId)
        // {
        //     Student student = await _main.GetById<Student>(studentId);
        //     Skip[] skips = await _skip.Where<Skip>(e => e.StudentId == studentId);
        //     Group group = await _main.GetById<Group>(student.GroupId);
        //     SReason[] sreason = await _skip.Where<SReason>(e => e.StudentId == studentId);

        //     var Skips = new List<ViewSkipShort>();
        //     foreach (Skip skip in skips)
        //     {
        //         var SReasonCount = sreason.Where(e => e.EduYear == skip.EduYear &&
        //                                               e.Semester == skip.Semester)
        //                                   .Select(e => e.Count).Sum();
        //         Skips.Add(new ViewSkipShort{
        //             EduYear = skip.EduYear,
        //             Semester = skip.Semester, 
        //             Count = skip.Count,
        //             SReasonCount = SReasonCount,
        //             ImgArr = sreason.Select(e => e.Img).ToArray(),
        //             TotalCount = skip.Count - SReasonCount,

        //         });
        //     }
        //     return Skips.OrderBy(e => e.EduYear).ToList();
        // }
        public async Task<List<ViewSkipShort>> SkipsShort(int studentId)
        {
            Student student = await _main.GetById<Student>(studentId);
            Models.Report[] skips = await _skip.Where<Models.Report>(e => e.StudentId == studentId);
            List<ViewSkipShort> result = new List<ViewSkipShort>();
            foreach (var el in skips)
            {
                var SReasonEl = await _skip.Where<Models.SReason>(e => e.Skip_Id == el.Id);
                try
                {
                    result.Add(new ViewSkipShort
                    {
                        Count = el.Count,
                        EduYear = el.EduYear,
                        ImgArr = SReasonEl.Select(e => e.Img).ToArray(),
                        Semester = el.Semester,
                        SReasonCount = SReasonEl.Sum(e => e.Count),
                        Month = el.Month,
                        SkipId = el.Id,
                    });
                }
                catch (NullReferenceException)
                {
                    result.Add(new ViewSkipShort
                    {
                        Count = el.Count,
                        EduYear = el.EduYear,
                        ImgArr = SReasonEl.Select(e => e.Img).ToArray(),
                        Semester = el.Semester,
                        SReasonCount = 0,
                        Month = el.Month,
                        SkipId = el.Id,
                    });
                }

            }

            return result;
        }
    
    
        public async Task<Models.SReason[]> GetRefer(int grId,int course, int semester, int Id ){
            var tempSkips = await _skip.First<service.Skips.Models.Report>(e => e.EduYear == course && e.Semester == semester && e.StudentId == Id);
            var result = await _skip.Where<service.Skips.Models.SReason>(e => e.Skip_Id == tempSkips.Id);
            return result;

        }
    
    }
}