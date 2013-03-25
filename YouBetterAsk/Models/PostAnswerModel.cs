using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouBetterAsk.Models
{
    public class PostAnswerModel
    {
        public int QuestionId { get; set; }
        public AnswerModel Answer { get; set; }
    }
}