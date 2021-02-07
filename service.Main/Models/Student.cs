using System;
namespace service.Main.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName => $"{Surname} {Name} {Patronymic}";
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Img { get; set; } = "";
        public int GroupId { get; set; } = 0;
        public bool Contract { get; set; }
        public string RecordBookNumber { get; set; }
        public string Note { get; set; } = "НЕ указано";
        public string BB { get; set; } = "Не указано";
    }
}