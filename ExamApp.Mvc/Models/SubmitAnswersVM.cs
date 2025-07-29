namespace ExamApp.Mvc.Models
{
    public class SubmitAnswersVM
    {
        public required int ExamId { get; set; }
        public double? Mark { get; set; }
        public List<AnswerVM>? Answers { get; set; } = new List<AnswerVM>();
    }

    public class AnswerVM
    {
        public required int QuestionId { get; set; }
        public required int OptionId { get; set; }
    }
}
