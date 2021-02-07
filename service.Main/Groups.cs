using service.Main.Models;
using service.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.Main
{
    public class Groups
    {
        private Repository _main;
        public Groups() => _main = new Repository();
        public async Task<ViewGroupDesc> GetGroupDesc(int GroupId)
        {
            Group group = await _main.GetById<Group>(GroupId);
            Department department = await _main.GetById<Department>(group.DepartmentId);
            ViewGroupDesc result = new ViewGroupDesc();

            result.Id = group.Id;
            result.EduStart = group.EduFrom;
            result.EduDuration = group.EduDuration;
            result.Name = group.Name;

            if (group.CuratorId == 0)
            {
                result.CuratorName = "Куратор не указан";
            }
            else
            {
                try
                {
                    var teacher = (await _main.GetById<Teacher>(group.CuratorId));
                    result.CuratorName = teacher.FullName;
                    result.CuratorId = teacher.Id;
                }
                catch (System.Exception)
                {
                    result.CuratorName = "Не найдено";
                }
            }
            if (group.HeadManId == 0)
            {
                result.HeadMan = "Староста не указан";
            }
            else
            {
                try
                {
                    result.HeadMan = (await _main.GetById<Student>(group.HeadManId)).FullName;
                }
                catch (System.Exception)
                {
                    result.HeadMan = "Не найдено";
                }
            }
            result.Department = department.Name;
            result.Speciality = group.Speciality;
            result.DepartmentId = department.Id;
            return result;
        }
        public async Task<ViewGroup[]> GetGroups(int DepartmentId)
        {
            List<ViewGroup> viewGroups = new List<ViewGroup>();
            Group[] groups = (await _main.Where<Group>(e => e.DepartmentId == DepartmentId)).OrderByDescending(e => e.EduFrom).ToArray();
            foreach (Group group in groups)
            {
                Student HeadMan = await _main.GetById<Student>(group.HeadManId);
                Teacher Curator = await _main.First<Teacher>(e => e.Id == group.CuratorId);
                Student[] students = await _main.Where<Student>(e => e.GroupId == group.Id);
                viewGroups.Add(
                    new ViewGroup
                    {
                        Id = group.Id,
                        Name = group.Name,
                        StudentsCount = students.Count(),
                        Curator = Curator == null ? "Куратор не указан" : Curator.FullName,
                        CuratorId = Curator == null ? 0 : Curator.Id,
                        HeadManId = HeadMan == null ? 0 : HeadMan.Id,
                        HeadMan = HeadMan == null ? "Староста не указан" : HeadMan.FullName,
                        Speciality = group.Speciality,
                        EduStart = group.EduFrom,
                        EduDuration = group.EduDuration,
                        IsFinished = group.Course >= group.EduDuration
                    }
                );
            }
            return viewGroups.OrderByDescending(e => e.EduStart).ToArray();
        }

        public async Task<(bool, int)> Add(Group obj)
        {
            if (obj.EduFrom > DateTime.Now.Year)
            {
                return (false, 0);
            }
            bool groups = (await _main.Where<Group>(e => e.Name == obj.Name &&
                                                         e.EduFrom == obj.EduFrom)).Any();
            if (!groups)
            {
                await _main.Add(obj);
                return (true, obj.Id);
            }
            else
            {
                return (false, 0);
            }
        }

        // public async void Remove(int Id){
        //     Group group = await _main.GetById<Group>(Id);
        //     Student[] students = await _main.Where<Student>(e => e.GroupId == group.Id);
        //     _main.RemoveGroup
        // }

    }
}