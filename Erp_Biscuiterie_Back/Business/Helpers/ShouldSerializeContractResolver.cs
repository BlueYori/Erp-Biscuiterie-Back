using System;
using System.Reflection;
using Erp_Biscuiterie_Back.Business.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Erp_Biscuiterie_Back.Business.Helpers
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(User) && property.PropertyName == "Role")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        return false;
                    };
            }

            return property;
        }
    }
}
