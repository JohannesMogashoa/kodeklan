using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace iTut.Models.HOD
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
