using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic_Game__Admin_.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        [Display(Name="Question Text")]
        public string QuestionText { get; set; }
        [Display(Name="Answer Text")]
        public string AnswerText { get; set; }
    }
}
