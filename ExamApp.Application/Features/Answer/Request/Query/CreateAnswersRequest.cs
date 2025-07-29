using ExamApp.Application.DTOs.Answer;
using ExamApp.Application.DTOs.ExamResult;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Answer.Request.Query
{
    public class CreateAnswersRequest : IRequest<BaseResponse<Unit>>
    {
        public required int ExamResultId { get; set; }
        public IEnumerable<CreateAnswerDto> Answers { get; set; }
    }
}
