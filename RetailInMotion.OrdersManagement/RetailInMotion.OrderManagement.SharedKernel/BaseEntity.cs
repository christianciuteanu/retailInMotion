namespace RetailInMotion.OrdersManagement.SharedKernel
{
    public abstract class BaseEntity<TId> where TId : struct
    {
        public TId Id { get; protected set; }
    }
}
