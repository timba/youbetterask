using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YouBetterAsk.Models;

namespace YouBetterAsk.Api
{
    public class BuzzDb : DbContext
    {
        public DbSet<QuestionModel> Questions { get; set; }
    }
}