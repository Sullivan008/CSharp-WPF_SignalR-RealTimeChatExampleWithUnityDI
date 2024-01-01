namespace SullyTech.Wpf.TraceListeners.BindingError.Exceptions;

internal sealed class DataBindingErrorException : Exception
{
    public DataBindingErrorException()
    { }

    public DataBindingErrorException(string? message) : base(message)
    { }

    public DataBindingErrorException(string? message, Exception innerException) : base(message, innerException)
    { }
}