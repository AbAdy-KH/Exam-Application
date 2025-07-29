using ExamApp.Application.Contracts.Persistence;
using ExamApp.Domain;
using ExamApp.Persistence.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Persistence.Repository
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly ExamAppDbContext _db;
        public ExamRepository(ExamAppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateExamStatus(Exam exam, bool IsActive)
        {
            exam.IsVisible = IsActive;

            _db.Update(exam);
        }
    }
}
