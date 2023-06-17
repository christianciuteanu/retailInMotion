using System.Runtime.Serialization;

namespace RetailInMotion.OrdersManagement.Core.Enums
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Confirmed")]
        Confirmed,

        [EnumMember(Value = "Canceled")]
        Canceled
    }
}
