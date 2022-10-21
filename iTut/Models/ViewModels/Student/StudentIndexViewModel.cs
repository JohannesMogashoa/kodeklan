
using iTut.Models.Shared;
using iTut.Models.Users;
using System.Collections.Generic;

namespace iTut.Models.ViewModels.Student
{
    public class StudentIndexViewModel
    {
        public StudentUser Student { get; set; }
        public List<TimelinePost> Posts { get; set; }
    }
}
