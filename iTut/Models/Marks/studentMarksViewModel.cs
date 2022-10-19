using System.Collections.Generic;
using iTut.Models.Users;
using iTut.Models.Coordinator;
using iTut.Models.Marks;

namespace iTut.Models.Marks
{
    public class studentMarksViewModel
    {
       
        public List<Subject> subjects { get; set; }
        public  List<Mark> marks { get; set; }
        public List<StudentUser> students { get; set; }
        
    }
}
