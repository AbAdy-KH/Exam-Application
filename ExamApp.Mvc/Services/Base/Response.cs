namespace ExamApp.Mvc.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
