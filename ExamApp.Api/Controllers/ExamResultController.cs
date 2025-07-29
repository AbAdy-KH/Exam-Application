using ExamApp.Application.DTOs.ExamResult;
using ExamApp.Application.Features;
using ExamApp.Application.Features.Answer.Request.Command;
using ExamApp.Application.Features.Answer.Request.Query;
using ExamApp.Application.Features.ExamResult.Request.Command;
using ExamApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExamResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //public async Task<ActionResult<BaseResponse<int>>> SaveExamResult(
        //[FromBody] CreateExamResultDto request)
        //{
        //    var response = await _mediator.Send(new CreateExamResultRequest() { CreateExamResultDto = request });

        //    return StatusCode((int)response.StatusCode, response);
        //}

        [HttpPost("WithAnswers")]
        public async Task<ActionResult<BaseResponse<int>>> SaveExamResultWithAnswers(
            [FromBody] CreateExamResultDto request)
        {
            var markResponse = await _mediator.Send(new CalculateAnswersMarkRequest() { answers = request.Answers });

            request.Mark = markResponse.Data;

            var ExamResultResponse = await _mediator.Send(new CreateExamResultRequest() { CreateExamResultDto = request});

            var CreateAnswersResponse = await _mediator.Send(new CreateAnswersRequest()
            {
                Answers = request.Answers,
                ExamResultId = ExamResultResponse.Data
            });

            return StatusCode((int)ExamResultResponse.StatusCode, ExamResultResponse);
        }
    }
}
