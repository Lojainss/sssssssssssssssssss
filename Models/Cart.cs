namespace E_Commerce.Models {
    public class Cart {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Product pro, int quantity = 1) {
            CartLine? line = Lines.FirstOrDefault(x => x.product.Id == pro.Id);
            if (line == null) {
                Lines.Add(new CartLine {
                    product = pro,
                    Quantity = quantity
                });
            } 
            else {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveItem(Product pro) {
            CartLine? line = Lines.FirstOrDefault(x => x.product.Id == pro.Id);
            if (line.Quantity > 1) {
                line.Quantity -= 1;
            } 
            else {
                RemoveLine(pro);
            }
        }
        public virtual void RemoveLine(Product pro) => Lines.RemoveAll(x => x.product.Id == pro.Id);
        public virtual decimal ComputeTotalValue() => Lines.Sum(x => x.product.Price * x.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine {
        public int CartLineID { get; set; }
        public Product product { get; set; } = new();
        public int Quantity { get; set; }
    }
}