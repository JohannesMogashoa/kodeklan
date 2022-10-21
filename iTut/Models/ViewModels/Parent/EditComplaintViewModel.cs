using iTut.Models.Parent;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace iTut.Models.ViewModels.Parent
{
    public class EditComplaintViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string ParentId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Complaint Body")]
        public string ComplaintBody { get; set; }

        public ComplaintStatus Status { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool Archived { get; set; } = false;
    }
}
