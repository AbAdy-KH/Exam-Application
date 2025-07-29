using AutoMapper;
using ExamApp.Mvc.Contracts;
using ExamApp.Mvc.Models;
using ExamApp.Mvc.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamApp.Mvc.Services
{
    public class ExamService :BaseHttpService,  IExamService
    {
        private readonly IMapper _mapper;

        public ExamService(IMapper mapper, IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<List<ExamVM>> GetAll()
        {

            AddBearerToken();
            var response = await _client.ExamGETAsync();

            List<ExamVM> exams = _mapper.Map<List<ExamVM>>(response.Data.ToList());

            return exams;
        }

        public async Task<ExamVM> Get(int Id)
        {
            AddBearerToken();

            var response = await _client.ExamGET2Async(Id);

            return _mapper.Map<ExamVM>(response.Data);
        }

        public async Task Update(ExamVM obj)
        {

            AddBearerToken();

            var exam = _mapper.Map<ExamDto>(obj);
            await _client.ExamPUTAsync(exam.Id, exam);
        }

        public async Task Delete(int Id)
        {
            AddBearerToken();
            await _client.ExamDELETEAsync(Id);
        }

        public async Task Create(CreateExamVM obj)
        {
            AddBearerToken();

            var exam = _mapper.Map<CreateExamDto>(obj);
            await _client.ExamPOSTAsync(exam);
        }

        public async Task<TakeExamVM> GetWholeExam(int examId)
        {
            AddBearerToken();
            var response = await _client.GetWholeExamAsync(examId);
            return _mapper.Map<TakeExamVM>(response.Data);
        }

        public async Task SubmitExam(SubmitAnswersVM vm)
        {
            try
            {
                AddBearerToken();
                var exam = _mapper.Map<CreateExamResultDto>(vm);

                await _client.WithAnswersAsync(exam);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mapping error: {ex.Message}");
                throw;
            }
        }
    }
}
