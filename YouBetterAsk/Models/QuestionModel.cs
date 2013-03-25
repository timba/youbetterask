using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YouBetterAsk.Models
{
    public class QuestionModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public UserModel User { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}