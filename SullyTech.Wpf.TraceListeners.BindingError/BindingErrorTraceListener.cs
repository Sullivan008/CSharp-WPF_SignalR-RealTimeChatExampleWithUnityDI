using System.Diagnostics;
using SullyTech.Wpf.TraceListeners.BindingError.Exceptions;

namespace SullyTech.Wpf.TraceListeners.BindingError;

public sealed class BindingErrorTraceListener : TraceListener
{
    public override void Write(string? message)
    { }

    public override void WriteLine(string? message)
    {
        throw new DataBindingErrorException(message);
    }
}