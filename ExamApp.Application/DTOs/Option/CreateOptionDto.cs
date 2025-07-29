using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Option
{
    public class CreateOptionDto : IOptionDto
    {
        public required string Text { get; set; }
        public required int QuestionId { get; set; }
        public required bool IsTrue { get; set; }
    }
}
