using Microsoft.EntityFrameworkCore;
using service.Main.Models;
using System;

namespace service.Main.Context
{
    public partial class MainContext : DbContext
    {
        public MainContext() { }
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        // private readonly string ContextPath = Directory.GetCurrentDirectory().Replace("University","service.Main") + "\\Context\\" + "University.Main.mdf";
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<service.Main.Models.Speciality> Specialities { get; set; }


        public DbSet<T> DbSet<T>() where T : class
        {

            if (typeof(T) == typeof(Department))
            {
                return this.Departments as dynamic;
            }
            else if (typeof(T) == typeof(Group))
            {
                return this.Groups as dynamic;
            }
            else if (typeof(T) == typeof(Student))
            {
                return this.Students as dynamic;
            }
            else if (typeof(T) == typeof(Speciality))
            {
                return this.Specialities as dynamic;
            }
            else if (typeof(T) == typeof(Teacher))
            {
                return this.Teachers as dynamic;
            }
            else
            {
                throw new Exception("DbSet not exist");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //   optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + ContextPath + ";Integrated Security=True");
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\_QOSH\\DOCUMENTS\\C#\\SERVICE.MAIN\\CONTEXT\\UNIVERSITY.MAIN.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.headOfDepId).HasColumnName("HeadOfDep_Id");

                entity.Property(e => e.Note).HasColumnName("Note");

            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Groups");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Key).HasColumnName("Name");

                entity.Property(e => e.HeadManId).HasColumnName("HeadMan_Id");

                entity.Property(e => e.CuratorId).HasColumnName("Curator_Id");

                entity.Property(e => e.Notes).HasColumnName("Notes");

                entity.Property(e => e.StudyForm).HasColumnName("StudyForm");

                entity.Property(e => e.EduFrom).HasColumnName("EduFrom");

                entity.Property(e => e.Speciality).HasColumnName("Speciality");

                entity.Property(e => e.EduLevel).HasColumnName("EduLevel");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.Surname).HasColumnName("Surname");

                entity.Property(e => e.Patronymic).HasColumnName("Patronymic");

                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");

                entity.Property(e => e.Email).HasColumnName("Email");

                entity.Property(e => e.Address).HasColumnName("Address");

                entity.Property(e => e.Birthday).HasColumnName("Birthday");

                entity.Property(e => e.Img).HasColumnName("Img");

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");


                entity.Property(e => e.Contract).HasColumnName("Contract");

                entity.Property(e => e.RecordBookNumber).HasColumnName("RecordBookNumber");

                entity.Property(e => e.Note).HasColumnName("Note");

                entity.Property(e => e.BB).HasColumnName("BB");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teachers");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.Surname).HasColumnName("Surname");

                entity.Property(e => e.Patronymic).HasColumnName("Patronymic");

                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");

                entity.Property(e => e.Email).HasColumnName("Email");

                entity.Property(e => e.AcademicDegree).HasColumnName("AcademicDegree");

                entity.Property(e => e.AcademicTitle).HasColumnName("AcademicTitle");

                entity.Property(e => e.BirthDay).HasColumnName("BirthDay");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentId");

                entity.Property(e => e.Login).HasColumnName("Login");

                entity.Property(e => e.Password).HasColumnName("Pass");

                entity.Property(e => e.Role).HasColumnName("Role");


            });

            modelBuilder.Entity<Speciality>(entity =>
            {

                entity.ToTable("Speciality");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}