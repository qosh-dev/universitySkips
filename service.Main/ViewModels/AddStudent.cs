using System;
using System.ComponentModel.DataAnnotations;

namespace service.Main.ViewModels
{
    public class AddStudentExcel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } = "Не указано";
        public string Address { get; set; } = "Не указано";
        public string Birthday { get; set; }
        public int Contract { get; set; }
        public string RecordBookNumber { get; set; }
        public string Note { get; set; } = "НЕ указано";
        public string BB { get; set; } = "НЕ указано";
    }
    public class AddStudentForm
    {
        [Required]
        [Display(Name = "Имя студента")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия студента")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Отчество студента")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Номер телефона студента")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Электронный адрес студента")]
        public string Email { get; set; } = "Не указано";

        [Display(Name = "Адрес студента")]
        public string Address { get; set; } = "Не указано";

        [Required]
        [Display(Name = "Дата рождения студента")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Аватарка студента студента")]
        public string Img { get; set; } = "";

        [Required]
        [Display(Name = "Форма оплаты обучения")]
        public bool Contract { get; set; }

        [Required]
        [Display(Name = "Код студенческого билета студента")]
        public string RecordBookNumber { get; set; }

        [Display(Name = "Характеристика студента")]
        public string Note { get; set; } = "НЕ указано";

        [Required]
        [Display(Name = "Группа студента")]
        public int GroupId { get; set; }

        [Display(Name = "Поддержка")]
        public string BB { get; set; } = "НЕ указано";
    }
}