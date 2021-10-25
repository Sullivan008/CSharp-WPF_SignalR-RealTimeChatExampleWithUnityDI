using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Application.Utilities.Extensions
{
    public static class EnumExtension
    {
        public static string GetEnumMemberAttrValue<TEnum>(this TEnum @this) where TEnum : Enum
        {
            EnumMemberAttribute enumMemberAttr = @this.GetAttribute<EnumMemberAttribute>();

            Guard.Guard.ThrowIfNullOrWhitespace(enumMemberAttr.Value, nameof(enumMemberAttr.Value));

            return enumMemberAttr.Value!;
        }

        private static TAttributeType GetAttribute<TAttributeType>(this Enum @this)
        {
            Type type = @this.GetType();
            MemberInfo[] memberInfo = type.GetMember(@this.ToString());

            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(TAttributeType), false);
            object? attribute = attributes.SingleOrDefault();

            Guard.Guard.ThrowIfNull(attribute, nameof(attribute));

            return (TAttributeType)attribute!;
        }
    }
}
