using ExamApp.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.UnitTest.Mock
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var mockExamResultRepo = MockExamResultRepo.GetExamResultRepository();
            mockUnitOfWork
                .Setup(u => u.examResultRepository)
                .Returns(mockExamResultRepo.Object);
            

            var mockAnswerRepo = MockAnswerRepo.GetAnswerRepository();
            mockUnitOfWork
                .Setup(u => u.answerRepository)
                .Returns(mockAnswerRepo.Object);    

            return mockUnitOfWork;
        }
    }
}
