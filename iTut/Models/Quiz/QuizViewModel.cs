using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        //public string QuizTittle { get; set; }
        public IEnumerable<SelectListItem> ListOfQuizzes { get; set; }
    }
}
