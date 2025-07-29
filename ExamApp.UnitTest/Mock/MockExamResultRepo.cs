using ExamApp.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.UnitTest.Mock
{
    public class MockExamResultRepo
    {
        public static Mock<IExamResultRepository> GetExamResultRepository()
        {
            var ExamResults = new List<ExamApp.Domain.ExamResult>()
                   {
                       new ExamApp.Domain.ExamResult() { Id = 1, ExamId = 1, Mark = 77, CreatedBy = "1" },
                       new ExamApp.Domain.ExamResult() { Id = 2, ExamId = 2, Mark = 62, CreatedBy = "1" }
                   };

            var mockExamResultRepo = new Mock<IExamResultRepository>();
            mockExamResultRepo
                .Setup(e => e.GetAll(null, null))
                .ReturnsAsync(ExamResults);

            mockExamResultRepo
                .Setup(e => e.Add(It.IsAny<Domain.ExamResult>()))
                .ReturnsAsync((Domain.ExamResult er) =>
                {
                    ExamResults.Add(er);
                    return er;
                });

            return mockExamResultRepo;
        }
    }
}
