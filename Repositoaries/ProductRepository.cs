namespace E_Commerce.Repository {
    public class ProductRepository : IProduct {
        private E_CommerceDbContext context;
        public ProductRepository(E_CommerceDbContext ctx) {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}