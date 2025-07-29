using ExamApp.Application.DTOs.Option;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Option.Request.Query
{
    public class GetOptionsWithQuestionIdRequest : IRequest<BaseResponse< List<OptionDto>>>
    {
        public int QuestionId { get; set; }
    }
}
