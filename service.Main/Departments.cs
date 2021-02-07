using service.Main.Models;
using service.Main.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace service.Main
{
    public class Departments
    {
        private Repository _main;
        public Departments()
        {
            _main = new Repository();
        }
        public async Task<List<ViewDepartment>> GetDepartments()
        {
            List<ViewDepartment> result = new List<ViewDepartment>();
            Department[] departments = await _main.Get<Department>();
            foreach (Department department in departments)
            {
                Teacher teacher = await _main.GetById<Teacher>(department.headOfDepId);
                Group[] groups = await _main.Where<Group>(e => e.DepartmentId == department.Id);
                result.Add(
                    new ViewDepartment
                    {
                        Name = department.Name,
                        Id = department.Id,
                        HeadMan = teacher.Name + " " + teacher.Surname + " " + teacher.Patronymic,
                        HeadManId = teacher.Id,
                        GroupCount = groups.Length
                    }
                );
            }
            return result;
        }
        public async void AddDepartment(Department obj)
        {
            var Id = await _main.Add(obj);
        }
    }
}