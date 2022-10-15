using System.Reflection;
using System.Runtime.Serialization;
using App.Core.Guard.Implementation;

namespace Application.Common.Utilities.Extensions;

public static class EnumExtension
{
    public static string GetEnumMemberAttrValue<TEnum>(this TEnum @this) where TEnum : Enum
    {
        EnumMemberAttribute enumMemberAttr = @this.GetAttribute<EnumMemberAttribute>();

        Guard.ThrowIfNullOrWhitespace(enumMemberAttr.Value, nameof(enumMemberAttr.Value));

        return enumMemberAttr.Value!;
    }

    private static TAttributeType GetAttribute<TAttributeType>(this Enum @this)
    {
        Type type = @this.GetType();
        MemberInfo[] memberInfo = type.GetMember(@this.ToString());

        object[] attributes = memberInfo[0].GetCustomAttributes(typeof(TAttributeType), false);
        object? attribute = attributes.SingleOrDefault();

        Guard.ThrowIfNull(attribute, nameof(attribute));

        return (TAttributeType)attribute!;
    }
}