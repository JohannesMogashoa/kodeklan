using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iTut.Models.Quiz
{
    public class Option
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OptionID { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";
        public string QuestionID { get; set; }
        public string OptionName { get; set; }
    }
}
