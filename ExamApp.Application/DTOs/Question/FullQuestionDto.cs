using ExamApp.Application.DTOs.Common;
using ExamApp.Application.DTOs.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Question
{
    public class FullQuestionDto : BaseDto
    {
        public QuestionDto Question { get; set; }
        public List<OptionDto> Options { get; set; }
    }
}
