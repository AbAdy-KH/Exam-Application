using ExamApp.Application.DTOs.Exam;
using ExamApp.Application.Features.Exam.Request.Command;
using ExamApp.Application.Features.Exam.Request.Query;
using ExamApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ExamController>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<ExamDto>>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllExamsRequest());

            return StatusCode((int)response.StatusCode, response);
        }

        // GET api/<ExamController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<ExamDto>>> Get(int id)
        {
            var response = await _mediator.Send(new GetExamInfoRequest() { Id = id });

            return StatusCode((int)response.StatusCode, response);
        }

        // POST api/<ExamController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateExamDto obj)
        {
            var response = await _mediator.Send(new CreateExamRequest() { createExamDto = obj });

            return StatusCode((int)response.StatusCode, response);
        }

        // PUT api/<ExamController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int Id, [FromBody] ExamDto obj)
        {
            obj.Id = Id; // Ensure the ID is set for the update operation
            var response = await _mediator.Send(new UpdateExamRequest() { updatedExam = obj });

            return StatusCode((int)response.StatusCode, response);
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteExamRequest() { Id = id });

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("GetWholeExam/{examId}")]
        public async Task<ActionResult<BaseResponse<ExamDto>>> GetWholeExam(int examId)
        {
            var response = await _mediator.Send(new GetWholeExamRequest() { examId = examId });

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
