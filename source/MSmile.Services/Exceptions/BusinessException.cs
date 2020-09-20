namespace MSmile.Services.Exceptions
{
    using System;

    /// <summary>
    /// Business exception.
    /// </summary>
    public class BusinessException : Exception
    {
        /// <inheritdoc />
        public BusinessException(string? message)
            : base(message)
        {
        }
    }
}
