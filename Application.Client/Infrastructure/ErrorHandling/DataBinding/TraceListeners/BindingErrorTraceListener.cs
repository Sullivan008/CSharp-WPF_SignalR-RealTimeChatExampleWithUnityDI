using System.Diagnostics;
using Application.Client.Infrastructure.ErrorHandling.DataBinding.Exceptions;

namespace Application.Client.Infrastructure.ErrorHandling.DataBinding.TraceListeners;

public class BindingErrorTraceListener : TraceListener
{
    public override void Write(string? message)
    { }

    public override void WriteLine(string? message)
    {
        throw new DataBindingErrorException(message);
    }
}