using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YouBetterAsk.Models;

namespace YouBetterAsk.Api
{
    public class BuzzController : ApiController
    {
        private IBuzzRepository buzzRepository = new BuzzRepository();

        [ActionName("question")]
        public IEnumerable<QuestionModel> Get()
        {
            return buzzRepository.GetQuestions().ToArray();
        }

        [ActionName("question")]
        public QuestionModel Get(int id)
        {
            return buzzRepository.GetQuestionById(id);
        }

        [ActionName("question")]
        public int Post([FromBody]QuestionModel question)
        {
            return buzzRepository.AddQuestion(question);
        }

        [ActionName("answer")]
        public int PostAnswer([FromBody]PostAnswerModel answer)
        {
            return buzzRepository.AddAnswer(answer.QuestionId, answer.Answer);
        }
    }
}