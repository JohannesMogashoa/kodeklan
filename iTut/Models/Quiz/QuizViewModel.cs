using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iTut.Models.Quiz
{
    public class QuizViewModel
    {

        [Required]
        public string QuizId { get; set; }
        [Required]
        public string QuestionName { get; set; }
        [Required]
        public string OptionName { get; set; }
        public string QuizName { get; set; }
    }
}
