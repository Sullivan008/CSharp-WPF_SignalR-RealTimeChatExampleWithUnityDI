using System.Reflection;
using System.Runtime.Serialization;

namespace SullyTech.Extensions.Enum;

public static class EnumExtensions
{
    public static string? GetEnumMemberAttrValue<TEnum>(this TEnum @this) where TEnum : System.Enum
    {
        EnumMemberAttribute enumMemberAttr = @this.GetAttribute<EnumMemberAttribute>();

        if (string.IsNullOrWhiteSpace(enumMemberAttr.Value))
        {
            return null;
        }

        return enumMemberAttr.Value;
    }

    private static TAttribute GetAttribute<TAttribute>(this System.Enum @this) where TAttribute : Attribute
    {
        Type type = @this.GetType();
        MemberInfo[] memberInfo = type.GetMember(@this.ToString());

        object[] attributes = memberInfo[0].GetCustomAttributes(typeof(TAttribute), false);
        object? attribute = attributes.SingleOrDefault();

        Guard.Guard.ThrowIfNull(attribute, nameof(attribute), $"{typeof(TAttribute).Name} attribute not defined in {type.Name} enum.");

        return (TAttribute)attribute!;
    }
}