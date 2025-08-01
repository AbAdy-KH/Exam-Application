﻿using ExamApp.Application.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.DTOs.Option
{
    public interface IOptionDto
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool IsTrue { get; set; }
    }
}
