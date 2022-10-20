using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iTut.Models.Users;
using iTut.Models.Coordinator;
using iTut.Models.Marks;

namespace iTut.Models.Marks
{
    public class Mark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";
        [ForeignKey("students")]
        public string StudentID { get; set; }
        [ForeignKey("subject")]
        public string SubjID { get; set; }
        [Required]
        [Range(1, 100)]
        public int Term1 { get; set; }
        [Required]
        [Range(1, 100)]

        public int Term2 { get; set; }
        [Required]
        [Range(1, 100)]

        public int Term3 {get;set; }
        [Required]
        [Range(1, 100)]

        public int Term4 { get; set; }
        public int Total { get; set; }

        public int avg {get; set; } 

        public string outcome { get; set; }

        public virtual Subject subject { get; set; }
        public virtual StudentUser students { get; set; }

    }
}
