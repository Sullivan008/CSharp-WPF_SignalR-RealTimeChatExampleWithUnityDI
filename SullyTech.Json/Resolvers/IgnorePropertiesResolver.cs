using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SullyTech.Json.Resolvers;

public sealed class IgnorePropertiesResolver : DefaultContractResolver
{
    private readonly HashSet<string> _properties;

    public IgnorePropertiesResolver(IEnumerable<string> properties)
    {
        _properties = new HashSet<string>(properties);
    }

    protected override JsonProperty CreateProperty(MemberInfo memberInfo, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(memberInfo, memberSerialization);

        if (_properties.Contains(property.PropertyName!))
        {
            property.ShouldSerialize = _ => false;
        }

        return property;
    }
}