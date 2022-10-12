using iTut.Models.Parent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace iTut.Models.ViewModels.Parent
{
    public class ParentViewModels
    {
        
    }
    public class EditMeetingRequestViewModel
    {
        [Required]
        public string Id { get; set; }
        public string Reason { get; set; }
        [Display(Name = "Meeting Date")]
        public DateTime MeetingDate { get; set; }
        public MeetingStatus Status { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool Archived { get; set; }
    }
}
