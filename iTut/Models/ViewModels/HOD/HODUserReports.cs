using iTut.Models.Users;
using System.Collections.Generic;
using iTut.Models.HOD;

namespace iTut.Models.ViewModels.HOD
{
    public class HODUserReports
    {
        public HODUser HODUser { get; set; }
        public List<StudentUser> StudentsUser { get; set; }
        public List<CoordinatorUser> CoordinatorUsers { get; set; }
        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
