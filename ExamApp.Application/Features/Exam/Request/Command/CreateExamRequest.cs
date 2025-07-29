using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Exam.Request.Command
{
    public class CreateExamRequest : IRequest<BaseResponse<int>>
    {
        public CreateExamDto createExamDto { get; set; }
    }
}
