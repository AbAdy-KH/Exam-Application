using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.Features.Question.Request.Command;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Question.Handler.Command
{
    public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionRequest, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeleteQuestionRequest request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.questionRepository.Get(q => q.Id == request.QuestionId);
            if (question is not null)
            {
                await _unitOfWork.questionRepository.Delete(question);

                await _unitOfWork.SaveChanges();
                return await BaseResponse<Unit>.SuccessResponse(Unit.Value);
            }
            else
            {
                return await BaseResponse<Unit>.FailureResponse("Not found", null, StatusCode.NotFound);
            }
        }
    }
}
