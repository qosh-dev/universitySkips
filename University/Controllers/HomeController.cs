using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service.Main;
using service.Main.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace University.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private service.Main.Repository _main = new service.Main.Repository();
        private service.Main.Specialities _spec = new Specialities();
        private Groups _group = new Groups();

        public async Task<IActionResult> Index()
        {
            var data = (await _group.GetGroups(1)).First(e => e.StudentsCount > 0);

            if (data == null)
            {
                initialCreate();
            }
            return LocalRedirect($"/Group/desc/{data.Id}");
        }

        public async Task<IActionResult> removeSpec(int dep, int Id)
        {
            _main.Remove<Speciality>(await _main.GetById<Speciality>(Id));
            return LocalRedirect("/Group/AddGroup/" + dep);
        }

        public async Task<IActionResult> addSpec(int Id)
        {
            dynamic result = new ExpandoObject();
            result.Id = Id;
            result.list = await _spec.Get(Id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> addSpec(int Id, string name)
        {
            await _main.Add(new Speciality
            {
                DepartmentId = Id,
                Name = name
            });
            return LocalRedirect("/Group/AddGroup/" + Id);
        }


        private async void initialCreate(){
            await _main.Add<Department>(new Department {
                    Name = "Естественно научный",
                    Note = "Без описания"
                });
                await _main.Add<Group>(new Group {
                    DepartmentId = 1,
                    EduFrom = DateTime.Now.Year,
                    EduLevel = "Бакалаврият",
                    Key = "A",
                    Notes = "Не указано",
                    StudyForm = "Очная",
                    Speciality = "Прикладная информатика",
                });
                for (int i = 0; i < 10; i++)
                {
                   await _main.Add<Student>(new Student{
                       Name = $"Student : {i+1}",
                       Address = "Address",
                       BB = "Не указано",
                       Birthday = DateTime.Now,
                       Contract = true,
                       Email = "Empty",
                       GroupId = 1,
                       Surname = "S",
                       Patronymic = "P",
                       PhoneNumber = "992900000000",
                       RecordBookNumber = $"test{i+1}",
                       Note = "Empty"
                    });
                }
                await _main.Add<Teacher>(new Teacher {
                    AcademicDegree = "Не указано",
                    AcademicTitle = "Не указано",
                    BirthDay = DateTime.Now,
                    DepartmentId = 1,
                    Email = "Не указано",
                    Login = "admin",
                    Password = "pass",
                    Name = "SUPERUSER",
                    Patronymic = "SUPERPATRONYMIC",
                    PhoneNumber = "123456789",
                    Role = "admin",
                    Surname = "SUPERSURNAME"
                });
        }



        // public async Task<IActionResult> departments(){
        //     var result = await _department.GetDepartments();
        //     return View(result);
        // }

        // [HttpPost]
        // public IActionResult AddDepartment(Department obj){
        //     _department.AddDepartment(obj);
        //     return LocalRedirect("/Home/departments");
        // }
        // public async Task<IActionResult> AddDepartment(){
        //     ViewBag.Teachers = await _main.Get<Teacher>();
        //     return View();
        // }

        public IActionResult logout()
        {
            HttpContext.SignOutAsync("Cookie");
            return LocalRedirect("/Home/login");
        }

        [AllowAnonymous]
        public IActionResult login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> login(string login, string pass)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Teacher teacher = await _main.First<Teacher>(e => e.Login == login && e.Password == pass);
            Student student = await _main.First<Student>(e => e.RecordBookNumber == login && e.RecordBookNumber == pass);
            if (teacher != null)
            {
                List<Claim> claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,teacher.Id.ToString())
                };
                var claimIdentity = new ClaimsIdentity(claims, "Cookie");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync("Cookie", claimPrincipal);
                return LocalRedirect("/Home/Index");
            }
            else if (student != null)
            {
                return LocalRedirect($"/Group/showSS?Id={student.GroupId}");
            }
            else
            {
                return LocalRedirect("/Home/Index");
            }

        }


    }
}















