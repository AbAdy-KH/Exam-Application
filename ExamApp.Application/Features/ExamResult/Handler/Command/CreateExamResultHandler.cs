using AutoMapper;
using ExamApp.Application.Contracts.Infrastructure;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.ExamResult;
using ExamApp.Application.Features.ExamResult.Request.Command;
using ExamApp.Application.Responses;
using ExamApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.ExamResult.Handler.Command
{
    public class CreateExamResultHandler : IRequestHandler<CreateExamResultRequest, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateExamResultHandler (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(CreateExamResultRequest request, CancellationToken cancellationToken)
        {
            //request.CreateExamResultDto.Mark = CalculateMark(request.CreateExamResultDto.Answers).Result;

            ExamApp.Domain.ExamResult examResult = _mapper.Map<ExamApp.Domain.ExamResult>(request.CreateExamResultDto);

            await _unitOfWork.examResultRepository.Add(examResult);
            await _unitOfWork.SaveChanges();

            return await BaseResponse<int>.SuccessResponse(examResult.Id);
        }
    }
}
