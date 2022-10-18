using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace iTut.Models.Coordinator
{
    public class SubjectEducator
    {
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SubjectEducatorId { get; set; } 

       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SubjectId { get; set; }

       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EducatorId { get; set; }

        public string GradeId { get; set; }
    }
}
