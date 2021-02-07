using service.Main.Models;
using service.Skips.Context;
using service.Skips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.Skips
{
    public class Repository
    {
        private Main.Repository _main = new Main.Repository();
        #region Change

        // public async void Change(int Id, SReason obj)
        // {
        //     using SkipContext _db = new SkipContext();
        //     SReason oldObj = _db.DbSet<SReason>().Find(Id);
        //     if(oldObj != null){
        //         if(obj.Skip_Id != 0) oldObj.StudentId = obj.StudentId;
        //         else if(obj.Img != null) oldObj.Img = obj.Img;
        //         else if(obj.Count != 0) oldObj.Count = obj.Count;
        //         else if(obj.Date != null) oldObj.Date = obj.Date;
        //     }
        //     await _db.SaveChangesAsync();
        // }

        public async Task<int> Change<T>(int Id, T obj) where T : class
        {
            using (SkipContext _db = new SkipContext())
            {
                var oldObj = _db.DbSet<T>().Find(Id);
                oldObj = obj;
                return await _db.SaveChangesAsync();
            }
        }

        #endregion


        public async void Add<T>(T obj)
        {
            using SkipContext _db = new SkipContext();
            await _db.AddAsync(obj);
            await _db.SaveChangesAsync();
        }

        public void Add<T>(T[] obj)
        {
            foreach (var el in obj) this.Add(el);
        }

        public async void Remove<T>(T obj)
        {
            using SkipContext _db = new SkipContext();
            _db.Remove(obj);
            await _db.SaveChangesAsync();
        }

        public void Remove<T>(T[] objList)
        {
            foreach (var el in objList) this.Remove(el);
        }

        public async void RemoveFromGroup(int Id)
        {
            try
            {
                Student[] students = await _main.Where<Student>(e => e.GroupId == Id);
                if (students.Count() != 0)
                {
                    foreach (var student in students)
                    {
                        this.RemoveStudentSkips(student.Id);
                    }
                }

            }
            catch (System.Exception)
            { }
        }
        public async void RemoveStudentSkips(int id)
        {
            var reports = await this.Where<Models.Report>(e => e.StudentId == id);
            foreach (var report in reports)
            {
                var SReasons = await this.Where<SReason>(e => e.Skip_Id == report.Id);
                foreach (var sreason in SReasons)
                {
                    this.Remove(sreason);
                }
                this.Remove(report);
            }
        }

        public async Task<T[]> Get<T>() where T : class
        {
            using SkipContext _db = new SkipContext();
            return await Task.Run(() => _db.DbSet<T>().ToArray());
        }

        public async Task<T[]> Where<T>(Func<T, bool> predicate) where T : class
        {
            using SkipContext _db = new SkipContext();
            IEnumerable<T> result = _db.DbSet<T>().Where(predicate);
            return await Task.Run(() => result.ToArray());
        }

        public async Task<T> GetById<T>(int Id) where T : class
        {
            using SkipContext _db = new SkipContext();
            return await Task.Run(() => _db.DbSet<T>().Find(Id));
        }

        public async Task<T> First<T>(Func<T, bool> predicate) where T : class
        {
            using SkipContext _db = new SkipContext();
            T result = _db.DbSet<T>().FirstOrDefault(predicate);
            return await Task.Run(() => result);
        }
        public async Task<T> First<T>() where T : class
        {
            using SkipContext _db = new SkipContext();
            T result = _db.DbSet<T>().FirstOrDefault();
            return await Task.Run(() => result);
        }


    }
}