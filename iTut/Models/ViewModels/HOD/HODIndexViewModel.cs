using iTut.Models.Users;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace iTut.Models.ViewModels.HOD
{
    public class HODIndexViewModel
    {
        public HODUser HodUser { get; set; }
        public class CalendarEvent
        {
            [Key]
            public int Id { get; set; }
            [Required]
            [Display(Name = "Start  Time")]
            public DateTime Start { get; set; }
            [Required]
            [Display(Name = "End Time")]
            public DateTime End { get; set; }
            [Required]
            [Display(Name = "Event Or Meeting Information")]
            public string Text { get; set; }
            [Required]
            public string Color { get; set; }
        }



    }

}
