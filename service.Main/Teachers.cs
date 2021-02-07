using service.Main.Context;
using service.Main.Models;
using System.Threading.Tasks;

namespace service.Main
{
    public class Teachers
    {

        private Repository _main;
        public Teachers()
        {
            _main = new Repository();
            // _db = new MainContext();
        }

        public async Task<Teacher[]> Get(int Id)
        {
            Teacher[] result = await _main.Where<Teacher>(e => e.DepartmentId == Id);
            return result;
        }

        public async void Change(int Id, Teacher teacher)
        {
            using MainContext _db = new MainContext();
            var old = _db.DbSet<Teacher>().Find(Id);
            old.AcademicDegree = teacher.AcademicDegree;
            old.AcademicTitle = teacher.AcademicTitle;
            old.BirthDay = teacher.BirthDay;
            old.DepartmentId = teacher.DepartmentId;
            old.Email = teacher.Email;
            old.Login = teacher.Login;
            old.Name = teacher.Name;
            old.Password = teacher.Password;
            old.Patronymic = teacher.Patronymic;
            old.PhoneNumber = teacher.PhoneNumber;
            old.Role = teacher.Role;
            old.Surname = teacher.Surname;
            await _db.SaveChangesAsync();
        }
    }
}