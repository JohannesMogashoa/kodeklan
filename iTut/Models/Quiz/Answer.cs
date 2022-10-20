using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iTut.Models.Quiz
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AnswerID { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";
        public string QuestionID { get; set; }
        public string AnswerText { get; set; }
    }
}
