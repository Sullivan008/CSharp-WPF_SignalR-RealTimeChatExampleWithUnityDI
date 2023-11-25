using SullyTech.Guid.Interfaces;

namespace SullyTech.Guid;

public sealed class Guid : IGuid
{
    public System.Guid NewGuid()
    {
        return System.Guid.NewGuid();
    }
}