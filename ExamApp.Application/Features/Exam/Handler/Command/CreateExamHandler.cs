using AutoMapper;
using ExamApp.Application.Contracts.Infrastructure;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Exam.Validation;
using ExamApp.Application.Features.Exam.Handler.Query;
using ExamApp.Application.Features.Exam.Request.Command;
using ExamApp.Application.Models;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Exam.Handler.Command
{
    public class CreateExamHandler : IRequestHandler<CreateExamRequest, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateExamHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseResponse<int>> Handle(CreateExamRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateExamDtoValidator();
            var validateResult = await validator.ValidateAsync(request.createExamDto);

            if (validateResult.IsValid)
            {
                var exam = _mapper.Map<ExamApp.Domain.Exam>(request.createExamDto);

                var createdExam = await _unitOfWork.examRepository.Add(exam);

                //
                //// here we must return exam id
                //


                var email = new Email()
                {
                    to = "abady11112005@gmail.com",
                    subject = "Creation Successed",
                    body = $"Exam info: \n{createdExam.ToString()}"
                };

                await _emailSender.SendEmail(email);

                await _unitOfWork.SaveChanges();
                return await BaseResponse<int>.SuccessResponse(1954876);
            }
            else
            {
                return await BaseResponse<int>.FailureResponse(
                    "Invalid Data",
                    validateResult.Errors.Select(e => e.ErrorMessage).ToList(),
                    StatusCode.BadRequest
                );
            }
        }
    }
}
