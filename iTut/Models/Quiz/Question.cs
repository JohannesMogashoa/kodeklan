using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iTut.Models.Quiz
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string QuestionID { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";
        public string QuizID { get; set; }
        public string QuestionName { get; set; }
      

    }
}
