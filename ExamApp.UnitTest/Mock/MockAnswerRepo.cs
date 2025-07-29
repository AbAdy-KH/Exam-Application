using ExamApp.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.UnitTest.Mock
{
    public class MockAnswerRepo
    {
        public static Mock<IAnswerRepository> GetAnswerRepository()
        {
            var Answers = new List<Domain.Answer>
            {
                new Domain.Answer { Id = 1, ExamResultId = 2, QuestionId = 1, OptionId = 1, CreatedBy = "1"},
                new Domain.Answer { Id = 2, ExamResultId = 2, QuestionId = 2, OptionId = 2, CreatedBy = "1"},
                new Domain.Answer { Id = 3, ExamResultId = 1, QuestionId = 1, OptionId = 1, CreatedBy = "1"},
                new Domain.Answer { Id = 4, ExamResultId = 1, QuestionId = 2, OptionId = 2, CreatedBy = "1"}
            };

            var mockAnswerRepo = new Mock<IAnswerRepository>();

            mockAnswerRepo
                .Setup(x => x.GetAll(null, null))
                .ReturnsAsync(Answers);

            mockAnswerRepo
                .Setup(x => x.AddRange(It.IsAny<IEnumerable<Domain.Answer>>()))
                .Returns((IEnumerable<Domain.Answer> answers) =>
                {
                    Answers.AddRange(answers);

                    return Task.CompletedTask;
                });


            return mockAnswerRepo;
        }
    }
}
