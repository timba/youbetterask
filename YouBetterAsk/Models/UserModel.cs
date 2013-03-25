using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YouBetterAsk.Models
{
    public class UserModel
    {
        [Key]
        public string Nickname { get; set; }
    }
}