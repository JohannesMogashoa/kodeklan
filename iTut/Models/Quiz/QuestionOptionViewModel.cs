using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace iTut.Models.Quiz
{
    public class QuestionOptionViewModel
    {
        public string QuizId { get; set; }
        public string QuestionName { get; set; }
        public string AnswerText { get; set; }
        
        public List<string> ListOfOptions { get; set; }
    }
} 