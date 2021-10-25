using System;

namespace Application.Client.Infrastructure.ErrorHandling.DataBinding.Exceptions
{
    public class DataBindingErrorException : Exception
    {
        public DataBindingErrorException()
        { }

        public DataBindingErrorException(string? message) : base(message)
        { }

        public DataBindingErrorException(string? message, Exception innerException) : base(message, innerException)
        { }
    }
}