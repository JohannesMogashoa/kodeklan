using iTut.Models.Shared;
using iTut.Models.Users;
using System.Collections.Generic;
namespace iTut.Models.ViewModels.Educator
{
    public class EducatorIndexViewModel
    {
        public EducatorUser Educator { get; set; }
        public List<TimelinePost> Posts { get; set; }
    }
}
