using AutoMapper;
using ExamApp.Application.Contracts.Infrastructure;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.Features.Exam.Request.Command;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Exam.Handler.Command
{
    public class DeleteExamHandler : IRequestHandler<DeleteExamRequest, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public DeleteExamHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseResponse<Unit>> Handle(DeleteExamRequest request, CancellationToken cancellationToken)
        {
            var obj = await _unitOfWork.examRepository.Get(e => e.Id == request.Id);

            if (obj is not null)
            {
                await _unitOfWork.examRepository.Delete(obj);

                await _unitOfWork.SaveChanges();
                return await BaseResponse<Unit>.SuccessResponse(Unit.Value);
            }
            else
            {
                return await BaseResponse<Unit>.FailureResponse(
                    $"Not found",
                    null,
                    StatusCode.NotFound
                );
            }
        }
    }
}
