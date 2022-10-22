using iTut.Models.Users;
using iTut.Models.Edu;
using iTut.Models.Coordinator;
using System.Collections.Generic;
using iTut.Models.Shared;

namespace iTut.Models.ViewModels.Coordinator
{
    public class CoordinatorIndexViewModel
    {
        public CoordinatorUser SubjectCoordinator { get; set; }
        public IEnumerable<CoordinatorUser> CoordinatorUsers { get; set; }
        public IEnumerable<EducatorUser> Educators { get; set; }
        public IEnumerable<ParentUser> Parents { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<TimelinePost> Posts { get; set; }
    }
}