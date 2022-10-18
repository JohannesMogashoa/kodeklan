using iTut.Constants;
using System.Collections.Generic;

namespace iTut.Models.ViewModels.Coordinator
{
    public class SubjectEducatorViewModel
    {
      

       
        public class EducatorUser
        {
            public string EducatorID { get; set; }
            public string EducatorLastName { get;set; }
            public string EducatorFirstName { get; set; }
            public string EducatorUserName { get; set; }    
        }
            public Grade Grade;
        public List<Grade> Grades;
        public string EducatorID { get;set;}
        //[reqired]
        public string SubjectName { get; set; }
    }
    
}
