using ExamApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain
{
    public class Exam : BaseDomainEntity
    {
        public required string Text { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public required bool IsVisible { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
