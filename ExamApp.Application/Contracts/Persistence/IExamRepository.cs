using ExamApp.Application.Contracts.Persistence.Common;
using ExamApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Contracts.Persistence
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task UpdateExamStatus(Exam exam, bool IsActive);
    }
}
