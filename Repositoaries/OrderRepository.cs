namespace E_Commerce.Repository {
    public class OrderRepository : IOrder {
        private E_CommerceDbContext context;
        public OrderRepository(E_CommerceDbContext ctx) {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders.Include(x => x.Lines).ThenInclude(x => x.product);
        public void AddOrder(Order order) {
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}