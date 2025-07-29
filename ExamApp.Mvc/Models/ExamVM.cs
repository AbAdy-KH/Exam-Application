namespace ExamApp.Mvc.Models
{
    public class ExamVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? Description { get; set; }
        public DateTime? Duration { get; set; }
        public bool IsVisible { get; set; }
    }
}
