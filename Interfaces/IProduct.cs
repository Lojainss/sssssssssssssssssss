namespace E_Commerce.Interfaces {
    public interface IProduct {
        IQueryable<Product> Products { get; }
    }
}