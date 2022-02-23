using System.Runtime.Serialization;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Cache;

public enum UserManagementCacheKey
{
    [EnumMember(Value = $"{nameof(UserManagement)}_{nameof(Users)}")]
    Users
}