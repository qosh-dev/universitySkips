using System;

namespace service.Skips.Models
{
    public class SReason
    {
        public int Id { get; set; }
        public int Skip_Id { get; set; }
        public string Img { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}