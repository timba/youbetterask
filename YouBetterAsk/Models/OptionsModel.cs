using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouBetterAsk.Models
{
    public class OptionsModel
    {
        public string GetPostsUrl { get { return "/api/buzz/question"; } }
        public string GetPostUrl { get { return "/api/buzz/question/"; } }
        public string AddPostUrl { get { return "/api/buzz/question"; } }
        public string AddCommentUrl { get { return "/api/buzz/answer"; } }
    }
}