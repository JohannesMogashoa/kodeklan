﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTut.Models.Parent
{
    public class Complaint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";

        [Required]
        public string ParentId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Complaint Body")]
        public string ComplaintBody { get; set; }

        [Display(Name = "Complaint Feedback")]
        public string Feedback { get; set; } = String.Empty;

        public ComplaintStatus Status { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
        
        public bool Archived { get; set; } = false;
    }

    public enum ComplaintStatus
    {
        Pending,
        Investigating,
        Resolved,
    }
}
