namespace service.Skips.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Month { get; set; }
        public int Count { get; set; }
        // public int SReason { get; set; }
        public int EduYear { get; set; }
        public int Semester { get; set; }
        // public int Total => Count - SReason;
    }
}