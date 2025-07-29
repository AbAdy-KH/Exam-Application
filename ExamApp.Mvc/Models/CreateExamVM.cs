namespace ExamApp.Mvc.Models
{
    public class CreateExamVM
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public string? Description { get; set; }
        public DateTime? Duration { get; set; }
        public required bool IsVisible { get; set; }
    }
}
