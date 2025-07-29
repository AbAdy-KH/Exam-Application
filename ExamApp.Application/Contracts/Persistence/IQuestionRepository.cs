using ExamApp.Application.Contracts.Persistence.Common;
using ExamApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Contracts.Persistence
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
         
    }
}
