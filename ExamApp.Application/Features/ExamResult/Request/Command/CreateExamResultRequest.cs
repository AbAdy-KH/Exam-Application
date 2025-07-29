using ExamApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ExamApp.Application.DTOs.ExamResult;

namespace ExamApp.Application.Features.ExamResult.Request.Command
{
    public class CreateExamResultRequest : IRequest<BaseResponse<int>>
    {
        public required CreateExamResultDto CreateExamResultDto { get; set; }
    }
}
