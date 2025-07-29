using ExamApp.Application.DTOs.Question;
using ExamApp.Application.Responses;
using MediatR;
using ExamApp.Application.Features.Question.Request.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExamApp.Application.Contracts.Persistence;

namespace ExamApp.Application.Features.Question.Handler.Query
{
    public class GetAllQuestionsHandler : IRequestHandler<GetAllQuestionsRequest, BaseResponse<List<QuestionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllQuestionsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<QuestionDto>>> Handle(GetAllQuestionsRequest request, CancellationToken cancellationToken)
        {
            var questions = await _unitOfWork.questionRepository.GetAll();

            var questionDtos = _mapper.Map<List<QuestionDto>>(questions);

            return await BaseResponse<List<QuestionDto>>.SuccessResponse(questionDtos);
        }
    }
}
