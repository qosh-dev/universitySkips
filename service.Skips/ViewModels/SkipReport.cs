using System.Collections.Generic;

namespace service.Skips.ViewModels
{
    public class SkipReport
    {
        public string FullName { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        public int Skips { get; set; }
        public int SReason { get; set; }
        public int TotalSkip { get; set; }

    }
    public class MonthReport
    {
        public int skipId;

        public int count { get; set; }
        public int sreason { get; set; }
        public int total { get; set; }
    }

    public class ReportToWorkSheet
    {
        // public string groupName;
        public string[] headersList;
        // public int eduStart;

        public List<string> names { get; set; }
        public string[] month { get; set; }

        public List<List<MonthReport>> data { get; set; }
        public List<string> bblist { get; set; }
    }
}