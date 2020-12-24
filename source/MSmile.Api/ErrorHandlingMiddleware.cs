namespace MSmile.Api
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    using MSmile.Services.Exceptions;

    /// <summary>
    /// Error handling middleware.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger<ErrorHandlingMiddleware> logger;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="next">Next delegate.</param>
        /// <param name="logger">Logger.</param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Invoke method
        /// </summary>
        /// <param name="context">Http context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (BusinessException ex)
            {
                this.logger.LogInformation(ex, "Business logic error");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"Bad request. The sent request could not be processed. Reason: {ex.Message}");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Unexpected error");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Unexpected error. See logs for the detail information.");
            }
        }
    }
}
