using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Responses
{
    public enum StatusCode
    {
        Success = 200,
        NotFound = 404,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        InternalServerError = 500
    }

    public class BaseResponse<T>
    {
        public bool Success{ get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }
        public StatusCode StatusCode { get; set; } = StatusCode.Success;

        public static async Task<BaseResponse<T>> SuccessResponse(T data, string? message = null, StatusCode statusCode = StatusCode.Success)
        {
            return new BaseResponse<T> { Success = true, Data = data, StatusCode = statusCode, Message = message };
        }

        public static async Task<BaseResponse<T>> FailureResponse(string message,  List<string>? errors = null, StatusCode statusCode = StatusCode.BadRequest)
        {
            return new BaseResponse<T> { Success = false, Message = message,StatusCode = statusCode, Errors = errors };
        }
    }
}
