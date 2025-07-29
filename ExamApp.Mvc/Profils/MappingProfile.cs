using AutoMapper;
using ExamApp.Mvc.Models;
using ExamApp.Mvc.Services.Base;

namespace ExamApp.Mvc.Profils
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<ExamDtoBaseResponse, Response<ExamVM>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data)).ReverseMap();


            //CreateMap<List<ExamDto>, List<ExamVM>>().ReverseMap();

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ExamDto, ExamVM>().ReverseMap();
            //});
            //config.AssertConfigurationIsValid();
            CreateMap<ExamVM, ExamDto>().ReverseMap();
            CreateMap<QuestionVM, QuestionDto>().ReverseMap();
            CreateMap<OptionVM, OptionDto>().ReverseMap();
            CreateMap<TakeExamVM, ExamDto>().ReverseMap();
            CreateMap<SubmitAnswersVM, CreateExamResultDto>().ReverseMap();
            CreateMap<CreateAnswerDto, AnswerVM>().ReverseMap();
            CreateMap<CreateExamDto,CreateExamVM>().ReverseMap();
            CreateMap<RegistrationRequest, RegisterVM>().ReverseMap();
        }
    }
}