using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Answer;
using ExamApp.Application.DTOs.ExamResult;
using ExamApp.Application.Features.Answer.Request.Command;
using ExamApp.Application.Features.Answer.Request.Query;
using ExamApp.Application.Features.ExamResult.Handler.Command;
using ExamApp.Application.Profiles;
using ExamApp.Application.Responses;
using ExamApp.UnitTest.Mock;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExamApp.UnitTest.Answer
{
    public class CreateAnswerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _moqUnitOfWork;
        private readonly List<CreateAnswerDto> _answersDto;
        private readonly CreateAnswersHandler _handler;

        public CreateAnswerTest()
        {
            _moqUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }));

            _answersDto = new List<CreateAnswerDto>
            {
                new CreateAnswerDto() { QuestionId = 1, OptionId = 1 },
                new CreateAnswerDto() { QuestionId = 2, OptionId = 2 },
                new CreateAnswerDto() { QuestionId = 3, OptionId = 3 }
            };

            _handler = new CreateAnswersHandler(_moqUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task Answer_CreateAnswers()
        {
            // Arrange
            var examResultId = 4; // Assuming this is a valid ExamResultId

            // Act  
            var result = await _handler.Handle(
                            new CreateAnswersRequest() { Answers = _answersDto, ExamResultId = examResultId }
                            , CancellationToken.None);
            var numAnswers = _moqUnitOfWork.Object.answerRepository.GetAll().Result.Count();

            // Assert  
            result.ShouldBeOfType<BaseResponse<Unit>>(); 
            numAnswers.ShouldBe(7);
        }
    }
}
