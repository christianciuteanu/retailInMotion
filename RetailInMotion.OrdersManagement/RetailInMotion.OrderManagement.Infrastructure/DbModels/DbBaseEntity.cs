namespace RetailInMotion.OrdersManagement.Infrastructure.DbModels
{
    internal class DbBaseEntity<T> where T : struct
    {
        public T Id { get; set; }
    }
}
