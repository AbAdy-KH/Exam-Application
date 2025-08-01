﻿using ExamApp.Application.Responses;

namespace ExamApp.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            
            BaseResponse<object> response = new BaseResponse<object>
            {
                StatusCode = StatusCode.InternalServerError,
                Message = "An unexpected error occurred.",
                Errors = new List<string> { exception.Message }
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
