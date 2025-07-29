using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Option;
using ExamApp.Application.Features.Option.Request.Query;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Option.Handler.Query
{
    public class GetOptionsWithQuestionIdHandler : IRequestHandler<GetOptionsWithQuestionIdRequest, BaseResponse<List<OptionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOptionsWithQuestionIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<OptionDto>>> Handle(GetOptionsWithQuestionIdRequest request, CancellationToken cancellationToken)
        {
            var Options = await _unitOfWork.optionRepository.GetAll(e => e.QuestionId == request.QuestionId);

            var res = _mapper.Map<List<OptionDto>>(Options);

            return await BaseResponse<List<OptionDto>>.SuccessResponse(res);
        }
    }
}
