using AutoMapper;
using ExamApp.Application.Contracts.Persistence;
using ExamApp.Application.DTOs.Option.Validation;
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
    public class UpdateOptionHandler : IRequestHandler<UpdateOptionRequest, BaseResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateOptionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Unit>> Handle(UpdateOptionRequest request, CancellationToken cancellationToken)
        {
            OptionValidatorDto validator = new OptionValidatorDto();
            var validationResult = validator.Validate(request.Option);

            if (validationResult.IsValid)
            {
                var option = await _unitOfWork.optionRepository.Get(o => o.Id == request.Option.Id);

                if (option is null)
                {
                    return await BaseResponse<Unit>.FailureResponse("Not found", null, StatusCode.NotFound);
                }
                else
                {
                    _mapper.Map(request.Option, option);

                    await _unitOfWork.optionRepository.Update(option);

                    await _unitOfWork.SaveChanges();
                    return await BaseResponse<Unit>.SuccessResponse(Unit.Value);
                }
            }
            else
            {
                return await BaseResponse<Unit>.FailureResponse(
                    "Invalid Data", validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }
    }
}
