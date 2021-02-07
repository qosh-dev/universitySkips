using System.ComponentModel.DataAnnotations;

namespace service.Main.ViewModels
{
    public class AddDepartment
    {
        [Required]
        [Display(Name = "Название кафедры")]
        public string Name { get; set; }

        [Display(Name = "Заведующий кафедры")]
        public string HeadOfDepartment { get; set; }

        [Display(Name = "Описание")]
        public string Note { get; set; }

    }
}