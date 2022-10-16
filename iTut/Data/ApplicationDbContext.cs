using iTut.Models.Parent;
using iTut.Models.Coordinator;
using iTut.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using iTut.Models.Edu;
using iTut.Models.UploadFiles;
using static iTut.Models.ViewModels.HOD.HODIndexViewModel;
using iTut.Models.Shared;

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

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
