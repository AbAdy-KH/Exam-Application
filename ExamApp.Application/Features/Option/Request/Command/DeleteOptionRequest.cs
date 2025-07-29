using ExamApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Features.Option.Request.Command
{
    public class DeleteOptionRequest : IRequest<BaseResponse<Unit>>
    {
        public int OptionId { get; set; }
    }
}
