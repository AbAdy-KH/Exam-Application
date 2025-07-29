using ExamApp.Application.DTOs.Question;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Question.Request.Query
{
    public class GetQuestionRequest : IRequest<BaseResponse<QuestionDto>>
    {
        public int QuestionId { get; set; }
    }
}
