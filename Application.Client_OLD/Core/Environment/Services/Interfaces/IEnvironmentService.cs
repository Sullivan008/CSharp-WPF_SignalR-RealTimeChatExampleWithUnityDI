using Application.Client.Core.Environment.Enums;

namespace Application.Client.Core.Environment.Services.Interfaces
{
    public interface IEnvironmentService
    {
        EnvironmentType GetEnvironmentType();
    }
}
