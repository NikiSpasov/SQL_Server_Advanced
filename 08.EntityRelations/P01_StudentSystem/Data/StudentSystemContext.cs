namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions options) :base(options){ }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        //public HomeworkSubmission HomeworkSubmissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.HasMany(s => s.HomeworkSubmissions)
                    .WithOne(e => e.Student)
                    .HasForeignKey(e => e.HomeworkId);

                entity.Property(s => s.Name)
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(s => s.PhoneNumber)
                    .IsUnicode(false)
                    .IsRequired(false)
                    .HasColumnType("CHAR(10)");

                entity.Property(s => s.Birthday).IsRequired(false);
            });

            model.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(s => s.Name)
                    .IsUnicode()
                    .HasMaxLength(80);

                entity.Property(s => s.Description)
                    .IsUnicode()
                    .IsRequired(false);

            });

            model.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(s => s.Name)
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(s => s.Url)
                    .IsUnicode(false);

                entity.HasOne(e => e.Course)
                    .WithMany(e => e.Resources)
                    .HasForeignKey(r => r.CourseId);
            });

            model.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(s => s.Content)
                    .IsUnicode(false);

                entity.HasOne(h => h.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(h => h.StudentId);

            });

            //model.Entity<HomeworkSubmission>(entity =>
            //{
            //    entity.HasOne(e => e.Student)
            //        .WithMany(s => s.HomeworkSubmissions)
            //        .HasForeignKey(hs => hs.StudentId);
            //});

            model.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new {e.StudentId, e.CourseId});

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(s => s.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(c => c.CourseId);
            });
        }
    }
}

