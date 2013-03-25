using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YouBetterAsk.Models
{
    public class AnswerModel
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public UserModel User { get; set; }
    }
}