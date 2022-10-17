using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTut.Models.Marks
{
    public class Mark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";
        public string StudentID { get; set; }
        public string SubjectID { get; set; }
        public int Term1 { get; set; }

        public int Term2 { get; set; }

        public int Term3 {get;set; }

        public int Term4 { get; set; }

        public int avg {get; set; } 

        public string outcome { get; set; }


    }
}
