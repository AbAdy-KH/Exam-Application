namespace ExamApp.Mvc.Models
{
    public class TakeExamVM
    {
        public int Id { get; set; }
        public ExamVM Exam { get; set; } = new ExamVM();
        public List<QuestionVM> Questions { get; set; } = new List<QuestionVM>();
        //public int TotalQuestions => Questions.Count;
    }

    public class QuestionVM
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public double? Grade { get; set; }
        public List<OptionVM> Options { get; set; } = new List<OptionVM>();
    }

    public class OptionVM
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsTrue { get; set; }
    }
}
