using AutoMapper;
using ExamApp.Application.DTOs.Answer;
using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.DTOs.ExamResult;
using ExamApp.Application.DTOs.Option;
using ExamApp.Application.DTOs.Question;
using ExamApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<Exam, CreateExamDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<Option, OptionDto>().ReverseMap();
            CreateMap<Option, CreateOptionDto>().ReverseMap();
            CreateMap<ExamResult, CreateExamResultDto>().ReverseMap();
            CreateMap<Answer, CreateAnswerDto>().ReverseMap();
        }
    }
}
