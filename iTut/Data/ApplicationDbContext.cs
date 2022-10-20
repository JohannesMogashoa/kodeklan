using iTut.Models.Parent;
using iTut.Models.Coordinator;
using iTut.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using iTut.Models.Edu;
using iTut.Models.Quiz;
using iTut.Models.Marks;
using iTut.Models.UploadFiles;
using static iTut.Models.ViewModels.HOD.HODIndexViewModel;
using iTut.Models.Shared;
using iTut.Models.HOD;
using System.Reflection.Emit;

using iTut.Constants;
namespace iTut.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            //HOD 
            builder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }

        // USERS
        public DbSet<ParentUser> Parents { get; set; }
        public DbSet<HODUser> HOD { get; set; }
        public DbSet<EducatorUser> Educator { get; set; }
        public DbSet<CoordinatorUser> SubjectCoordinator { get; set; }
        public DbSet<StudentUser> Students { get; set; }

        // Parent Tables
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<MeetingRequest> MeetingRequest { get; set; }

        public DbSet<CalendarEvent> Events { get; set; }
        public DbSet<TimelinePost> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }

        // Educator Tables
        public DbSet<Topic> Topics { get; set; }
        public DbSet<FileOnDatabase> FilesOnDatabase { get; set; }
        public DbSet<Quiz> Quizzes { get;set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }


        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Report> Reports { get; set; }

        //HOD Table
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<SubjectEducator> SubjectEducators { get; set; }
        public DbSet<FeedbackEducator> FeedbackEducator { get; set; }
    }
}
