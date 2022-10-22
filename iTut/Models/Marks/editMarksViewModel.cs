using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using iTut.Constants;
using System;

namespace iTut.Models.Marks
{
    public class editMarksViewModel:Mark
    {
        public string Id { get; set; } 

        public string StudentID { get; set; }
      
        public string SubjID { get; set; }
        [Required]
        [Range(1, 100)]
        public int Term1 { get; set; }
        [Required]
        [Range(1, 100)]

        public int Term2 { get; set; }
        [Required]
        [Range(1, 100)]

        public int Term3 { get; set; }
        [Required]
        [Range(1, 100)]

        public int Term4 { get; set; }
        public int Total { get; set; }

        public int avg { get; set; }

        public string outcome { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public Grade grade { get; set; }

    }
}
