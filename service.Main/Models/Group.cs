using System;

namespace service.Main.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name
        {
            get
            {
                var result = "";

                var firstStep = Speciality.Split(" ");
                if (firstStep.Length > 1)
                {
                    for (int i = 0; i < firstStep.Length; i++)
                    {
                        result += firstStep[i][0];
                    }
                }
                else
                {
                    result = Speciality;
                }
                if (Course >= EduDuration)
                {
                    return EduDuration + " " + result + " " + Key;
                }
                else
                {
                    return Course + " " + result + " " + Key;
                }
            }
        }
        public int HeadManId { get; set; } = 0;
        public int CuratorId { get; set; } = 0;
        public string Speciality { get; set; }
        public string Notes { get; set; } = "Описание не указано";
        public int EduFrom { get; set; }
        public int EduDuration => EduLevel switch
        {
            "Бакалаврият" => 4,
            "Магистратура" => 2,
            "Аспирантура" => 3,
            _ => 4
        };
        public int EduTo => EduFrom + EduDuration;
        public int Course => DateTime.Now.Year - EduFrom + 1;
        public string EduLevel { get; set; }
        public string StudyForm { get; set; }
        public int DepartmentId { get; set; }
        public int Semester => lib.Methods.GetSemestry();
    }
}