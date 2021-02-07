using System.ComponentModel.DataAnnotations;

namespace service.Main.ViewModels
{
    public class AddGroupForm
    {
        [Required]
        [Display(Name = "Ключ группы")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Год начала обучения")]
        public int EduFrom { get; set; }

        [Required]
        [Display(Name = "Специальность")]
        public string Speciality { get; set; }


        [Display(Name = "Куратор")]
        public int CuratorId { get; set; }

        [Required]
        [Display(Name = "Кафедра")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Уровень")]
        public string EduLevel { get; set; }

        [Required]
        [Display(Name = "Форма обучения")]
        public string StudyForm { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Note { get; set; }
    }
}