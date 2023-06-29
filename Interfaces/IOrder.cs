namespace E_Commerce.Interfaces {
    public interface IOrder {
        public IQueryable<Order> Orders { get; }
        public void AddOrder(Order order);
    }
}