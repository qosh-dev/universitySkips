using service.Main.Context;
using service.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.Main
{
    public class Repository
    {
        #region Change
        public async void Change(Student newObj)
        {
            using MainContext _db = new MainContext();
            Student oldObj = _db.DbSet<Student>().Find(newObj.Id);
            oldObj.Address = newObj.Address;
            oldObj.BB = newObj.BB;
            oldObj.Name = newObj.Name;
            oldObj.Note = newObj.Note;
            oldObj.Birthday = newObj.Birthday;
            oldObj.Contract = newObj.Contract;
            oldObj.Email = newObj.Email;
            oldObj.GroupId = newObj.GroupId;
            oldObj.Img = newObj.Img;
            oldObj.Patronymic = newObj.Patronymic;
            oldObj.PhoneNumber = newObj.PhoneNumber;
            oldObj.RecordBookNumber = newObj.RecordBookNumber;
            oldObj.Surname = newObj.Surname;
            await _db.SaveChangesAsync();
        }


        public async void Change(int Id, Group obj)
        {
            using MainContext _db = new MainContext();
            var oldObj = _db.DbSet<Group>().Find(Id);
            oldObj.Key = obj.Key;
            oldObj.HeadManId = obj.HeadManId;
            oldObj.CuratorId = obj.CuratorId;
            oldObj.StudyForm = obj.StudyForm;
            oldObj.Notes = obj.Notes;
            oldObj.EduFrom = obj.EduFrom;
            oldObj.Speciality = obj.Speciality;
            oldObj.DepartmentId = obj.DepartmentId;
            oldObj.EduLevel = obj.EduLevel;
            oldObj.StudyForm = obj.StudyForm;
            await _db.SaveChangesAsync();
        }
        public async Task<bool> isContein<T>(T obj) where T : class
        {
            using MainContext _db = new MainContext();
            return await Task.Run(() => _db.DbSet<T>().Where(e => e == obj).Any());
        }

        public void Change(int Id, Department obj)
        {
            using MainContext _db = new MainContext();
            Department oldObj = _db.DbSet<Department>().Find(Id);
            if (oldObj != null)
            {
                if (obj.Name != null) oldObj.Name = obj.Name;
                else if (obj.headOfDepId != 0) oldObj.headOfDepId = obj.headOfDepId;
                else if (obj.Note != null) oldObj.Name = obj.Note;
            }
            _db.SaveChangesAsync();
        }

        #endregion


        public async Task<T> Add<T>(T obj)
        {
            using MainContext _db = new MainContext();
            await _db.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;

        }


        public async void Remove<T>(T obj)
        {
            using MainContext _db = new MainContext();
            _db.Remove(obj);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RemoveGroup(Group obj)
        {
            try
            {
                using MainContext _db = new MainContext();

                var students = _db.DbSet<Student>().Where(e => e.Id == obj.Id).ToList();
                foreach (var student in students)
                {
                    _db.DbSet<Student>().Remove(student);
                }
                _db.Remove(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<T[]> Get<T>() where T : class
        {
            using MainContext _db = new MainContext();
            return await Task.Run(() => _db.DbSet<T>().ToArray());
        }

        public async Task<T[]> Where<T>(Func<T, bool> predicate) where T : class
        {
            using MainContext _db = new MainContext();
            IEnumerable<T> result = _db.DbSet<T>().Where(predicate);
            return await Task.Run(() => result.ToArray());
        }

        public async Task<T> GetById<T>(int Id) where T : class
        {
            using MainContext _db = new MainContext();
            return await Task.Run(() => _db.DbSet<T>().Find(Id));
        }

        public async Task<T> First<T>(Func<T, bool> predicate) where T : class
        {
            using MainContext _db = new MainContext();
            T result = _db.DbSet<T>().FirstOrDefault(predicate);
            return await Task.Run(() => result);
        }
        public async Task<T> First<T>() where T : class
        {
            using MainContext _db = new MainContext();
            T result = _db.DbSet<T>().FirstOrDefault();
            return await Task.Run(() => result);
        }




    }
}