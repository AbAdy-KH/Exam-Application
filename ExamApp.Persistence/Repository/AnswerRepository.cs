using ExamApp.Application.Contracts.Persistence;
using ExamApp.Domain;
using ExamApp.Persistence.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Persistence.Repository
{
    public class AnswerRepository : GenericRepository<Domain.Answer>, IAnswerRepository
    {
        private readonly ExamAppDbContext _dbContext;
        public AnswerRepository(ExamAppDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task AddRange(IEnumerable<Answer> Answers)
        {
            await _dbContext.Answers.AddRangeAsync(Answers);
        }
    }
}
