using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iTut.Models.Quiz
{
    public class Result
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ResultID { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";
        public string QuestionID { get; set; }
        public string StudentID { get; set; }
        public string AnswerText { get; set; }

    }
}
