using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;


namespace RetailInMotion.OrdersManagement.Api
{
    public class EnumConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            var enumValue = value as Enum;
            if (enumValue != null)
            {
                var enumMemberAttribute = enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttributes(false)
                    .OfType<EnumMemberAttribute>()
                    .FirstOrDefault();

                if (enumMemberAttribute != null)
                {
                    writer.WriteValue(enumMemberAttribute.Value);
                    return;
                }
            }

            base.WriteJson(writer, value, serializer);
        }
    }
}
