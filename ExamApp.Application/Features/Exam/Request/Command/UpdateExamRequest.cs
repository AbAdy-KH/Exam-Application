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
    public class UpdateExamRequest : IRequest<BaseResponse<Unit>>
    {
        public ExamDto updatedExam { get; set; }
    }
}
