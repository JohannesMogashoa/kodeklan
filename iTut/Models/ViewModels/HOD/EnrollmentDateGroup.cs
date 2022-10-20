using System.ComponentModel.DataAnnotations;
using System;

namespace iTut.Models.ViewModels.HOD
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
