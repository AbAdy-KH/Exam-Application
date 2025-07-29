using AutoMapper;
using ExamApp.Application.Contracts.Infrastructure;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Exam.Request.Query
{
    public class GetAllExamsRequest : IRequest <BaseResponse<List<ExamDto>>>
    {
    }
}
