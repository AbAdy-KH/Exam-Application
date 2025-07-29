using ExamApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain
{
    public class Option : BaseDomainEntity
    {
        public required string Text { get; set; }
        [ForeignKey(nameof(Question))]
        public required int QuestionId { get; set; }
        public Question? Question { get; set; }
        public required bool IsTrue { get; set; }
    }
}
