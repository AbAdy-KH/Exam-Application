using ExamApp.Application.DTOs.Question;
using ExamApp.Application.Features.Exam.Request.Query;
using ExamApp.Application.Features.Question.Request.Command;
using ExamApp.Application.Features.Question.Request.Query;
using ExamApp.Application.Responses;
using ExamApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public async Task<ActionResult< BaseResponse<IEnumerable<QuestionDto>>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllQuestionsRequest());

            return StatusCode((int)response.StatusCode, response);
        }

        // GET api/<QuestionController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<BaseResponse<QuestionDto>>> Get(int Id)
        {
            var response = await _mediator.Send(new GetQuestionRequest() { QuestionId = Id});

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("exam/{examId}")]
        public async Task<ActionResult<BaseResponse<IEnumerable<QuestionDto>>>> GetByExamId(int examId)
        {
            var response = await _mediator.Send(new GetQuestionsWithExamIdRequest() { ExamId = examId });
            return StatusCode((int)response.StatusCode, response);
        }

        // POST api/<QuestionController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateQuestionDto obj)
        {
            var response = await _mediator.Send(new CreateQuestionRequest() { Question = obj});
            return StatusCode((int)response.StatusCode, response);
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int Id, [FromBody] QuestionDto obj)
        {
            obj.Id = Id; // Ensure the ID is set for the update operation
            var response = await _mediator.Send(new UpdateQuestionRequest() { Question = obj });
            return StatusCode((int)response.StatusCode, response);
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteQuestionRequest() { QuestionId = id });
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
