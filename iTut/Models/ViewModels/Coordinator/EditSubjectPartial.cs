using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace iTut.Models.ViewModels.Coordinator
{
    public class EditSubjectPartial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]

        [Display(Name = "Subject description")]
        public string SubjectDescr { get; set; }
        public string Grade { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
