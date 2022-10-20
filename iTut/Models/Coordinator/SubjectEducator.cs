using System.ComponentModel.DataAnnotations.Schema;
using System;
using iTut.Models.Users;
using iTut.Constants;

namespace iTut.Models.Coordinator
{
    public class SubjectEducator
    {
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SubjectEducatorId { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Subject")]
        public string SubjectId { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Educator")]
        public string EducatorId { get; set; }
        [ForeignKey("Grades")]
        public string GradeId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual EducatorUser Educator { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
