using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iTut.Constants;

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
       

        //public List<Subject> Subjects { get; set; }
        //public string SearchString { get; set; }

        //[Display(Name = "Educator Name")]
        //public string EducatorId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        
        [Display(Name = "Subject description")]
        public string SubjectDescr { get; set; }
        public Grade Grade { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public Statuses Status { get; set; }
        public string EducatorID { get; internal set; }
        

        //public string LastName { get; set; }

        public enum Statuses
        {
            Active,
            Inactive
        }
    }
}
