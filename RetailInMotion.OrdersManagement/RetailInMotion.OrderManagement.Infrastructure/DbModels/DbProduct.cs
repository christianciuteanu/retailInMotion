namespace RetailInMotion.OrdersManagement.Infrastructure.DbModels
{
    internal class DbProduct : DbBaseEntity<Guid>
    {
        public string ProductName { get; set; }
    }
}
