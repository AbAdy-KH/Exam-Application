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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly ExamAppDbContext _db;
        public QuestionRepository(ExamAppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
