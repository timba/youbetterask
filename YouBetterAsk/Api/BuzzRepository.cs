using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YouBetterAsk.Models;

namespace YouBetterAsk.Api
{
    public class BuzzRepository : IBuzzRepository
    {
        public IEnumerable<QuestionModel> GetQuestions()
        {
            return Do(context => context.Questions.OrderByDescending(q => q.Id).ToArray() );
        }

        public QuestionModel GetQuestionById(int id)
        {
            return Do(context =>
            {
                var qq = context.Questions
                    .Include(q => q.User)
                    .Include(q => q.Answers)
                    .Include(q => q.Answers.Select(a => a.User))
                    .FirstOrDefault(q => q.Id == id);
                return qq;
            });
        }

        public int AddQuestion(QuestionModel question)
        {
            return Do(context =>
            {
                var newq = context.Questions.Add(question);
                context.SaveChanges();
                return newq.Id;
            });
        }

        public int AddAnswer(int questionId, AnswerModel answer)
        {
            return Do(context =>
            {
                var question = context.Questions.FirstOrDefault(q => q.Id == questionId);
                question.Answers = new List<AnswerModel>();
                question.Answers.Add(answer);
                context.SaveChanges();
                return answer.Id;
            });
        }

        private TRes Do<TRes>(Func<BuzzDb, TRes> action)
        {
            using (var context = new BuzzDb())
            {
                return action(context);
            }
        }
    }
}