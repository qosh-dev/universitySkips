namespace service.Main.ViewModels
{
    public class ViewGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsCount { get; set; }
        public string Curator { get; set; }
        public int CuratorId { get; set; }
        public string HeadMan { get; set; }
        public int HeadManId { get; set; }
        public string Speciality { get; set; }
        public int EduStart { get; set; }
        public bool IsFinished { get; internal set; }
        public int EduDuration { get; internal set; }
    }
}