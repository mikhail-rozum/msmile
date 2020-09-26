namespace MSmile.Api
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using MSmile.Services.Exceptions;

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="next">Next delegate.</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (BusinessException ex)
            {
                // TODO: return appropriate response
            }
            catch (Exception ex)
            {
                // TODO: log exception and then return appropriate response
            }
        }
    }
}
