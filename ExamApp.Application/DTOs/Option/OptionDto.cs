using ExamApp.Application.DTOs.Common;
using ExamApp.Application.DTOs.Question;
using ExamApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Option
{
    public class OptionDto : BaseDto, IOptionDto
    {
        public required string Text { get; set; }
        public required int QuestionId { get; set; }
        //public QuestionDto? Question { get; set; }
        public required bool IsTrue { get; set; }
    }
}
