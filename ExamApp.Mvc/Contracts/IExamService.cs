using ExamApp.Mvc.Models;
using ExamApp.Mvc.Services.Base;

namespace ExamApp.Mvc.Contracts
{
    public interface IExamService
    {
        public Task<ExamVM> Get(int Id); 
        public Task<List<ExamVM>> GetAll(); 
        public Task Create(CreateExamVM vm);
        public Task Delete(int id);
        public Task Update(ExamVM vm);

        public Task<TakeExamVM> GetWholeExam(int examId);
        public Task SubmitExam(SubmitAnswersVM vm);
    }
}
