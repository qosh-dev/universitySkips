namespace service.Main.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; } = 0;
    }
}