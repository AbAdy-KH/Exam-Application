using ExamApp.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamAppDbContext _context;
        private IExamRepository _examRepository;
        private IQuestionRepository _questionRepository;
        private IOptionRepository _optionRepository;
        private IExamResultRepository _examResultRepository;
        private IAnswerRepository _answerRepository;

        public UnitOfWork(ExamAppDbContext context)
        {
            _context = context;
        }


        public IExamRepository examRepository =>
            _examRepository ??= new ExamRepository(_context);

        public IQuestionRepository questionRepository =>
            _questionRepository ??= new QuestionRepository(_context);

        public IOptionRepository optionRepository =>
            _optionRepository ??= new OptionRepository(_context);

        public IExamResultRepository examResultRepository =>
            _examResultRepository ??= new ExamResultRepository(_context);

        public IAnswerRepository answerRepository =>
            _answerRepository ??= new AnswerRepository(_context);



        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
