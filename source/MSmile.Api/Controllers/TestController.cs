namespace MSmile.Api.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Services.Exceptions;

    /// <summary>
    /// Test controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        /// <summary>
        /// Throws BusinessException
        /// </summary>
        [HttpGet("throwBusinessException")]
        public IActionResult ThrowBusinessException()
        {
            throw new BusinessException("Some message");
        }

        /// <summary>
        /// Throws unknown exception
        /// </summary>
        /// <returns></returns>
        [HttpGet("throwUnknownException")]
        public IActionResult ThrowUnknownException()
        {
            throw new Exception("Unexpected exception message");
        }
    }
}
