using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.Features.Answer.Request.Query;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Answer.Request.Command
{
    public class CreateAnswersHandler : IRequestHandler<CreateAnswersRequest, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateAnswersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(CreateAnswersRequest request, CancellationToken cancellationToken)
        {
            var answers = _mapper.Map<IEnumerable<Domain.Answer>>(request.Answers);

            foreach(var answer in answers)
            {
                answer.ExamResultId = request.ExamResultId;
            }

            await _unitOfWork.answerRepository.AddRange(answers);
            await _unitOfWork.SaveChanges();

            return await BaseResponse<Unit>.SuccessResponse(Unit.Value, "Answers created successfully", StatusCode.Success);
        }
    }
}
