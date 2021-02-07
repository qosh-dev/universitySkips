using Microsoft.EntityFrameworkCore;
using service.Skips.Models;
using System;

namespace service.Skips.Context
{
    public partial class SkipContext : DbContext
    {
        public SkipContext() { }
        public SkipContext(DbContextOptions<SkipContext> options) : base(options) { }

        //  private readonly string ContextPath = Directory.GetCurrentDirectory().Replace("University", "service.Skips") + "\\Context\\" + "University.Skip.mdf";
        public virtual DbSet<service.Skips.Models.Report> Reports { get; set; }
        public virtual DbSet<SReason> SReasons { get; set; }

        public DbSet<T> DbSet<T>() where T : class
        {
            if (typeof(T) == typeof(service.Skips.Models.Report))
            {
                return this.Reports as dynamic;
            }
            else if (typeof(T) == typeof(SReason))
            {
                return this.SReasons as dynamic;
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
                //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ ContextPath + ";Integrated Security=True");
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\_QOSH\\DOCUMENTS\\C#\\SERVICE.SKIPS\\CONTEXT\\UNIVERSITY.SKIP.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<SReason>(entity =>
            {
                entity.ToTable("SReason");

                entity.Property(e => e.Skip_Id).HasColumnName("Skip_Id");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Img).HasColumnName("Img");

                entity.Property(e => e.Count).HasColumnName("Count");

                entity.Property(e => e.Date).HasColumnName("Date");

            });

            modelBuilder.Entity<service.Skips.Models.Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.EduYear).HasColumnName("edu_year");

                entity.Property(e => e.Semester).HasColumnName("semester");

            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}