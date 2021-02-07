namespace service.Main.ViewModels
{
    public class ViewStudent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public string Img { get; set; }
        public string Group { get; set; }
        public int GroupId { get; set; }
        public string StudyForm { get; set; }
        public string EduLevel { get; set; }
        public bool Contract { get; set; }
        public string RecordBookNumber { get; set; }
        public string Curator { get; set; }
        public int CuratorId { get; set; }
        public string Speciality { get; set; }
        public string Department { get; set; }
        public int DepartmentId { get; set; }
        public int Course { get; set; }
        public int EduFrom { get; set; }
        public int EduTo { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; internal set; }
        public int Id { get; internal set; }
    }
}