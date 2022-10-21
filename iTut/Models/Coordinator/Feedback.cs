using iTut.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTut.Models.Coordinator
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";

        [Required]
        [Display(Name = "Educator Name")]
        public string EducatorId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Feedback")]
        public string FeedbackContent { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual EducatorUser Educator { get; set; }
    }
}
