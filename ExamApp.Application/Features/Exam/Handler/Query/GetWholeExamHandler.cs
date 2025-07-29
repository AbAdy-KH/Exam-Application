using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.DTOs.Option;
using ExamApp.Application.DTOs.Question;
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
    public class GetWholeExamHandler : IRequestHandler<GetWholeExamRequest, BaseResponse<ExamDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetWholeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<ExamDto>> Handle(GetWholeExamRequest request, CancellationToken cancellationToken)
        {
            var Exam = await _unitOfWork.examRepository.Get(e => e.Id == request.examId, "Questions,Questions.Options");

            if(Exam is null)
            {
                return await BaseResponse<ExamDto>.FailureResponse("Exam not found");
            }
            else
            {
                return await BaseResponse<ExamDto>.SuccessResponse(
                    _mapper.Map<ExamDto>(Exam));
            }

            //if (Exam is not null)
            //{
            //    FullExamDto fullExamDto = new FullExamDto();

            //    fullExamDto.Exam = _mapper.Map<ExamDto>(Exam);
            //    fullExamDto.Questions = new List<FullQuestionDto>();


            //    var Questions = await _unitOfWork.questionRepository.GetAll(q => q.ExamId == request.examId);

            //    var QuestionsDto = _mapper.Map<List<QuestionDto>>(Questions);

            //    foreach (var question in QuestionsDto)
            //    {
            //        var options = await _unitOfWork.optionRepository.GetAll(o => o.QuestionId == question.Id);

            //        var optionsDto = _mapper.Map<List<OptionDto>>(options);

            //        var fullQuestionDto = new FullQuestionDto
            //        {
            //            Question = question,
            //            Options = optionsDto
            //        };

            //        fullExamDto.Questions.Add(fullQuestionDto);
            //    }

            //    return await BaseResponse<FullExamDto>.SuccessResponse(fullExamDto);
            //}
            //else
            //{
            //    return await BaseResponse<FullExamDto>.FailureResponse("Exam not found", null, StatusCode.BadRequest);
            //}
        }
    }
}
