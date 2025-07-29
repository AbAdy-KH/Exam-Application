using ExamApp.Application.DTOs.Common;
using ExamApp.Application.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Exam
{
    public class FullExamDto : BaseDto
    {
        public ExamDto Exam { get; set; }
        public List<FullQuestionDto> Questions { get; set; }
    }
}
