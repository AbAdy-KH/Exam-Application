using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.Features.Option.Request.Command;
using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Option.Handler.Command
{
    public class DeleteOptionHandler : IRequestHandler<DeleteOptionRequest, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteOptionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeleteOptionRequest request, CancellationToken cancellationToken)
        {
            var option = await _unitOfWork.optionRepository.Get(o => o.Id == request.OptionId);
            if (option is null)
            {
                return await BaseResponse<Unit>.FailureResponse("Not found", null, StatusCode.NotFound);
            }
            else
            {
                await _unitOfWork.optionRepository.Delete(option);

                await _unitOfWork.SaveChanges();
                return await BaseResponse<Unit>.SuccessResponse(Unit.Value);
            }
        }
    }
}
