using System.ComponentModel.DataAnnotations;

namespace service.Main.ViewModels
{
    public class EditGroup : AddGroupForm
    {
        [Display(Name = "Староста")]
        public int HeadmanId { get; set; }
        public int IdToEdit { get; set; }
    }
}