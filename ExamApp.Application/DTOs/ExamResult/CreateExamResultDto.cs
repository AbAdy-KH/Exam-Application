using ExamApp.Application.DTOs.Answer;
using ExamApp.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.ExamResult
{
    public class CreateExamResultDto
    {
        public required int ExamId { get; set; }
        public double? Mark { get; set; }
        [NotMapped]
        public List<CreateAnswerDto>? Answers { get; set; } = new List<CreateAnswerDto>();
    }}
