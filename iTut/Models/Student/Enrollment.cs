using System;
using iTut.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iTut.Models.Student
{
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";

        
        public StudentUser Student { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        public string Grade { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string StudentEmail { get; set; }

    }
}
