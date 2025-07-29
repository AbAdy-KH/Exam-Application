using ExamApp.Application.DTOs.Answer;
using ExamApp.Application.DTOs.ExamResult;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Answer.Request.Command
{
    public class CalculateAnswersMarkRequest : IRequest<BaseResponse<double?>>
    {
        public List<CreateAnswerDto> answers { get; set; } = new List<CreateAnswerDto>();
    }
}
