using AutoMapper;
using ExamApp.Application.Contracts.Infrastructure;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.Features.Exam.Request.Query;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Exam.Handler.Query
{
    public class GetAllExamsHandler : IRequestHandler<GetAllExamsRequest, BaseResponse<List<ExamDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public GetAllExamsHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseResponse<List<ExamDto>>> Handle(GetAllExamsRequest request, CancellationToken cancellationToken)
        {
            var Exams = await _unitOfWork.examRepository.GetAll();

            return await BaseResponse<List<ExamDto>>.SuccessResponse(
                        _mapper.Map<List<ExamDto>>(Exams)
                    );
        }
    }
}
