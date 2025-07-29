using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.Features.Question.Request.Command;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Question.Handler.Command
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionRequest, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
        {
            // Don't forget to validate the request here if needed

            var question = _mapper.Map<Domain.Question>(request.Question);
            
            await _unitOfWork.questionRepository.Add(question);

            await _unitOfWork.SaveChanges();
            return await BaseResponse<int>.SuccessResponse(199999);
        }
    }
}
