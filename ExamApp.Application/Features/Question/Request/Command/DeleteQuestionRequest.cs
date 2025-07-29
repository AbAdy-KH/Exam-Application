using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Question.Request.Command
{
    public class DeleteQuestionRequest : IRequest<BaseResponse<Unit>>
    {
        public int QuestionId { get; set; }
    }
}
