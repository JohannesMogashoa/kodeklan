using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iTut.Constants;
namespace iTut.Models.Quiz
{
    public class Quiz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string QuizId { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";
        public string QuizTittle { get; set; }
        public string QuizDescription { get; set; }
        public string EducatorID { get; set; }
        public string TopicId { get; set; }
        public Grade Grade { get; set; }
        public string SubjectID { get; set; }
        public quizStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public enum quizStatus
        {
            Active,
            Expired,
        }

    }
}
