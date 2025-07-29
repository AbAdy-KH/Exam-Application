using ExamApp.Application.Contracts.Persistence;
using ExamApp.Domain;
using ExamApp.Persistence.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Persistence.Repository
{
    public class ExamResultRepository : GenericRepository<ExamResult>, IExamResultRepository
    {
        public ExamResultRepository(ExamAppDbContext db) : base(db)
        {
        }
    }
}
