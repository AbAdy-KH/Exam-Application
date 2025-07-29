using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.ExamResult;
using ExamApp.Application.Features.Answer.Request.Command;
using ExamApp.Application.Responses;
using ExamApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Answer.Handler.Command
{
    public class CalculateAnswersMarkHandler : IRequestHandler<CalculateAnswersMarkRequest, BaseResponse<double?>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CalculateAnswersMarkHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<double?>> Handle(CalculateAnswersMarkRequest request, CancellationToken cancellationToken)
        {
            double? res = 0;
            foreach (var answer in request.answers)
            {
                Domain.Question question = await _unitOfWork.questionRepository.Get(
                    q => q.Id == answer.QuestionId, includeProperties: "Options");

                var option = question.Options.FirstOrDefault(o => o.Id == answer.OptionId);
                if (option != null && option.IsTrue)
                {
                    res += question.Grade;
                }
            }

            return await BaseResponse<double?>.SuccessResponse(res);
        }
    }
}
