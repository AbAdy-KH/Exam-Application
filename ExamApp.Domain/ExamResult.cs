using ExamApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain
{
    public class ExamResult : BaseDomainEntity
    {
        [ForeignKey("Exams")]
        public required int ExamId { get; set; }
        public double? Mark { get; set; }
        //public double? GreatestMark { get; set; }
        [NotMapped]
        public Exam? Exam { get; set; }
        [NotMapped]
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
