using ExamApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain
{
    public class Question : BaseDomainEntity
    {
        public required string Text { get; set; }
        [ForeignKey("Exams")]
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
        public double? Grade { get; set; }
        public List<Option> Options { get; set; } = new List<Option>();
    }
}
