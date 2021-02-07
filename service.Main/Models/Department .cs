using System.ComponentModel.DataAnnotations;

namespace service.Main.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название кафедры")]
        public string Name { get; set; }

        [Display(Name = "Заведующий кафедры")]
        public int headOfDepId { get; set; } = 0;

        [Display(Name = "Описание")]
        public string Note { get; set; } = "Описание не указано";

    }
}