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
    public class GetQuestionsWithExamIdHandler : IRequestHandler<GetQuestionsWithExamIdRequest, BaseResponse<List<QuestionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetQuestionsWithExamIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<QuestionDto>>> Handle(GetQuestionsWithExamIdRequest request, CancellationToken cancellationToken)
        {
            var questions = await _unitOfWork.questionRepository.GetAll(q => q.ExamId == request.ExamId);

            var questionDtos = _mapper.Map<List<QuestionDto>>(questions);

            return await BaseResponse<List<QuestionDto>>.SuccessResponse(questionDtos);
        }
    }
}
