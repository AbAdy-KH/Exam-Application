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
    public class OptionRepository : GenericRepository<Option>, IOptionRepository
    {
        private readonly ExamAppDbContext _db;
        public OptionRepository(ExamAppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
