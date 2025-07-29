using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.Features.Exam.Request.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Domain;
using ExamApp.Application.Responses;

namespace ExamApp.Application.Features.Exam.Handler.Query
{
    public class GetExamInfoHandler : IRequestHandler<GetExamInfoRequest, BaseResponse<ExamDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExamInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<BaseResponse<ExamDto>> Handle(GetExamInfoRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ExamDto>(); // Fully qualify the 'Exam' type to avoid ambiguity

            ExamApp.Domain.Exam exam = await _unitOfWork.examRepository.Get(e => e.Id == request.Id);

            if (exam is not null)
            {
                return await BaseResponse<ExamDto>.SuccessResponse(
                    _mapper.Map<ExamDto>(exam)
                );
            }
            else
            {
                return await BaseResponse<ExamDto>.FailureResponse("Not found", null, StatusCode.BadRequest);
            }
        }
    }
}
