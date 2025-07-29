using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Question;
using ExamApp.Application.Features.Question.Request.Query;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Question.Handler.Query
{
    public class GetQuestionHandler : IRequestHandler<GetQuestionRequest, BaseResponse<QuestionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<QuestionDto>> Handle(GetQuestionRequest request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.questionRepository.Get(e=> e.Id == request.QuestionId);
            if (question is null)
            {
                return await BaseResponse<QuestionDto>.FailureResponse($"Not found");
            }

            var questionDto = _mapper.Map<QuestionDto>(question);
            return await BaseResponse<QuestionDto>.SuccessResponse(questionDto);
        }
    }
}
