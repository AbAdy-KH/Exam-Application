using ExamApp.Application.DTOs.Option;
using ExamApp.Application.Features.Option.Handler.Query;
using ExamApp.Application.Features.Option.Request.Command;
using ExamApp.Application.Features.Option.Request.Query;
using ExamApp.Application.Responses;
using ExamApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private IMediator _mediator;
        public OptionController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<OptionController>
        [HttpGet("Question/{questionId}")]
        public async Task<ActionResult<BaseResponse<IEnumerable<OptionDto>>>> Get(int questionId)
        {
            var response = await _mediator.Send(new GetOptionsWithQuestionIdRequest {QuestionId = questionId});
            return StatusCode((int)response.StatusCode, response);
        }

        // POST api/<OptionController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateOptionDto obj)
        {
            var response = await _mediator.Send(new CreateOptionRequest { Option = obj });
            return StatusCode((int)response.StatusCode, response);
        }

        // PUT api/<OptionController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int Id, [FromBody] OptionDto obj)
        {

            obj.Id = Id; // Ensure the ID is set for the update operation
            var response = await _mediator.Send(new UpdateOptionRequest { Option = obj });
            return StatusCode((int)response.StatusCode, response);
        }

        // DELETE api/<OptionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteOptionRequest { OptionId = id});
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
