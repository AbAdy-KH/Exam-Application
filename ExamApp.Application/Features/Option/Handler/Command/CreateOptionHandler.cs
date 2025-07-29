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
    public class CreateOptionHandler : IRequestHandler<CreateOptionRequest, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateOptionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(CreateOptionRequest request, CancellationToken cancellationToken)
        {
            CreateOptionValidator validator = new CreateOptionValidator();
            var validationResult = validator.Validate(request.Option);

            if (validationResult.IsValid)
            {
                var res = _mapper.Map<Domain.Option>(request.Option);

                await _unitOfWork.optionRepository.Add(res);

                await _unitOfWork.SaveChanges();
                return await BaseResponse<int>.SuccessResponse(res.Id);
            }
            else
            {
                return await BaseResponse<int>.FailureResponse(
                    "Invalid Data", validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }
    }
}
