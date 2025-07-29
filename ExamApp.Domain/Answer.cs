using ExamApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain
{
    public class Answer : BaseDomainEntity
    {
        [ForeignKey("ExamResults")]
        public required int ExamResultId { get; set; }
        [ForeignKey("Questions")]
        public required int QuestionId { get; set; }
        [NotMapped]
        public Question? Question { get; set; }
        public required int OptionId { get; set; }
        [NotMapped]
        public Option? Option { get; set; }
    }
}