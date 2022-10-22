using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTut.Models.Coordinator
{
    public class FeedbackEducator
    {
        public string FeedbackEducatorId { get; set; }
        [Required]
        public string EducatorId { get; set; }

        [Required]
        public string FeedbackContent { get;set;}
      //  public string CreatedAt { get; set; }
    }
}
