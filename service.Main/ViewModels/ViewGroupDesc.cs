namespace service.Main.ViewModels
{
    public class ViewGroupDesc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CuratorName { get; set; }
        public int EduStart { get; set; }
        public int EduDuration { get; set; }
        public string HeadMan { get; set; }
        public string Department { get; set; }
        public string Speciality { get; set; }
        public int DepartmentId { get; internal set; }
        public int CuratorId { get; internal set; }
        // public Student[] Students { get; set; }
    }
}