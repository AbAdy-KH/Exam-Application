using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExamApp.Application.Features.ExamResult.Request.Command;
using ExamApp.Application.DTOs.ExamResult;
using ExamApp.Application.Features.ExamResult.Handler.Command;
using ExamApp.Application.Contracts.Persistence;
using Moq;
using ExamApp.Domain;
using AutoMapper;
using ExamApp.Application.Responses;
using Shouldly;
using ExamApp.UnitTest.Mock;
using ExamApp.Application.Profiles;

namespace ExamApp.UnitTest.ExamResult
{
    public class CreateExamResultTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _moqUnitOfWork;
        private readonly CreateExamResultDto _examResultDto;
        private readonly CreateExamResultHandler _handler;

        public CreateExamResultTest()
        {
            _moqUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }));

            _examResultDto = new CreateExamResultDto() { ExamId = 1 };

            _handler = new CreateExamResultHandler(_moqUnitOfWork.Object, _mapper);
        }

        [Fact]
        public async Task ExamResult_CreateExamResult()
        {
            // Act  
            var result = await _handler.Handle(
                            new CreateExamResultRequest() { CreateExamResultDto = _examResultDto }
                            , CancellationToken.None);

            var numExamResults = _moqUnitOfWork.Object.examResultRepository.GetAll().Result.Count();

            // Assert  
            result.ShouldBeOfType<BaseResponse<int>>(); // This line now works because Shouldly is added
            numExamResults.ShouldBe(3); // 2 existing + 1 new exam result
        }
    }
}
