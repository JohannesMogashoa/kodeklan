using System;
using System.ComponentModel.DataAnnotations;
using iTut.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTut.Models.Edu
{
    public class Topic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TopicId { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";
        [ForeignKey("Educator")]
        public string EducatorID { get; set; }
        [Required]

        [Display(Name = "Catetgory Name/Topics")]
        public string TopicName { get; set; }

        public TopicStatus Status { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
        public enum TopicStatus
        {
            Active,
            NotActive,
        }
        public virtual EducatorUser Educator { get; set; } 
    }
}
