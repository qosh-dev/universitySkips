using System;
using System.ComponentModel.DataAnnotations;

namespace service.Main.Models
{
    public class Teacher
    {
        public int Id { get; set; } = 0;
        public string FullName => $"{Surname} {Name} {Patronymic}";

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Электронный адрес")]
        public string Email { get; set; } = "Не указано";

        [Display(Name = "AcademicDegree")]
        public string AcademicDegree { get; set; } = "Не указано";

        [Display(Name = "AcademicTitle")]
        public string AcademicTitle { get; set; } = "Не указано";

        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; } = DateTime.Now;
        public int DepartmentId { get; set; } = 0;

        [Display(Name = "Логин")]
        public string Login { get; set; } = "null";

        [Display(Name = "Пароль")]
        public string Password { get; set; } = "null";

        [Display(Name = "Роль")]
        public string Role { get; set; } = "User";
    }
}