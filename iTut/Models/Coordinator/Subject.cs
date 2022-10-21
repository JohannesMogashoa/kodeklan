using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTut.Models.Coordinator
{
    public class Subject
    {
        //Grade enums
        //public enum Grade
        //{
        //   11;
        //}


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
