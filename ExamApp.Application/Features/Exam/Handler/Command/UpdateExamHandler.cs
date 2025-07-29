using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.DTOs.Exam.Validation;
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
    public class UpdateExamHandler : IRequestHandler<UpdateExamRequest, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(UpdateExamRequest request, CancellationToken cancellationToken)
        {
            var validator = new ExamDtoValidator();
            var validateResult = await validator.ValidateAsync(request.updatedExam);

            if(validateResult.IsValid == true)
            {
                var obj = await _unitOfWork.examRepository.Get(e => e.Id == request.updatedExam.Id);

                if (obj is not null)
                {
                    // Fix: The Map method does not return a Task, so it should not be awaited.
                    _mapper.Map(request.updatedExam, obj);

                    await _unitOfWork.examRepository.Update(obj);

                    await _unitOfWork.SaveChanges();
                    return await BaseResponse<Unit>.SuccessResponse(Unit.Value);
                }
                else
                {
                    return await BaseResponse<Unit>.FailureResponse("Not found", null, StatusCode.NotFound);
                }
            }
            else
            {
                return await BaseResponse<Unit>.FailureResponse(
                    "Invalid Data",
                    validateResult.Errors.Select(e => e.ErrorMessage).ToList(),
                    StatusCode.BadRequest
                );
            }
        }
    }
}
