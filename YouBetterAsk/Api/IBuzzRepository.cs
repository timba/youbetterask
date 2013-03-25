using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouBetterAsk.Models;

namespace YouBetterAsk.Api
{
    public interface IBuzzRepository
    {
        IEnumerable<QuestionModel> GetQuestions();
        QuestionModel GetQuestionById(int id);
        int AddQuestion(QuestionModel question);
        int AddAnswer(int questionId, AnswerModel answer);
    }
}
