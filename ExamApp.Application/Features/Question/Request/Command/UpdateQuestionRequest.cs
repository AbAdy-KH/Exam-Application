using ExamApp.Application.DTOs.Question;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Question.Request.Command
{
    public class UpdateQuestionRequest : IRequest<BaseResponse<Unit>>
    {
        public QuestionDto Question { get; set; }
    }
}
