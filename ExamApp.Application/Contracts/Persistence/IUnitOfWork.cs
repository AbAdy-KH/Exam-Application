using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        public IExamRepository examRepository { get; }
        public IQuestionRepository questionRepository { get; }
        public IOptionRepository optionRepository { get; }
        public IExamResultRepository examResultRepository { get; }
        public IAnswerRepository answerRepository { get; }

        public Task SaveChanges();
    }
}
