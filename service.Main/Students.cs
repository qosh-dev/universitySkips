using Excel;
using Microsoft.AspNetCore.Mvc;
using service.Main.Models;
using service.Main.ViewModels;
using System.Threading.Tasks;

namespace service.Main
{
    public class Students
    {
        private Repository _main;
        public Students() => _main = new Repository();

        public async Task<ViewStudent> StudentDesc(int Id)
        {
            Student student = await _main.GetById<Student>(Id);
            Group group = await _main.GetById<Group>(student.GroupId);
            Teacher curator = await _main.GetById<Teacher>(group.CuratorId);
            Department department = await _main.GetById<Department>(curator.DepartmentId);
            return new ViewStudent
            {
                Id = student.Id,
                Name = student.FullName,
                Email = student.Email,
                Birthday = lib.Methods.date(student.Birthday.ToString()),
                Img = student.Img,
                GroupId = group.Id,
                Group = group.Name,
                Address = student.Address,
                StudyForm = group.StudyForm,
                EduLevel = group.EduLevel,
                Contract = student.Contract,
                RecordBookNumber = student.RecordBookNumber,
                Curator = curator.FullName ?? "Не указано",
                CuratorId = curator.Id,
                Speciality = group.Speciality,
                DepartmentId = department.Id,
                PhoneNumber = student.PhoneNumber,
                Department = department.Name,
                Course = group.Course,
                EduFrom = group.EduFrom,
                EduTo = group.EduTo,
                Note = student.Note
            };
        }


        public async Task<int> addStudent(Student obj)
        {
            Student student = await _main.First<Student>(e =>
                                                         e.FullName == obj.FullName &&
                                                         e.Birthday == obj.Birthday &&
                                                         e.GroupId == obj.GroupId);
            if (student == null)
            {
                var ret = await _main.Add(obj);
                return ret.Id;
            }
            else
            {
                return 0;
            }
        }

        public FileContentResult template(ControllerBase obj)
        {
            var headers = new string[]{
                "Имя",
                "Фамилия",
                "Отчество",
                "Номер телефона",
                "Адрес электронной почты",
                "Адрес",
                "Дата рождения (формат = 10/24/2020)",
                "Метод оплаты (0,1)",
                "Код студента",
                "Характеристика",
                "Поддержка"
            };

            return obj.Excel(e =>
            {
                e.addWorkSheet("AddStudentForm")
                 .AddHeaders(headers);
            }, fileName: "addStudentTemplate");
        }
    }
}