namespace E_Commerce.Controllers {
    public class HomeController: Controller {
        private IProduct Product;
        private IOrder Order;
        private Cart cart;
        public HomeController(IProduct pro, IOrder ord ,Cart ca) {
            Product = pro;
            cart = ca;
            Order = ord;
        }
        public IActionResult Index() => View(Product);

        public IActionResult Preview(int Id) => View(Product.Products.FirstOrDefault(x => x.Id == Id));
        public IActionResult Cart(int Id = 0) {
            return View(cart);
        }
        public IActionResult AddToCart(int Id) {
            Product? pro = Product.Products.FirstOrDefault(x => x.Id == Id);
            if (pro != null) {
                cart.AddItem(pro);
            }
            ViewBag.Id = Id;
            return View("Cart", cart);
        }
        public IActionResult RemoveItem(int Id) {
            Product? pro = Product.Products.FirstOrDefault(x => x.Id == Id);
            if (pro != null) {
                cart.RemoveItem(pro);
            }
            return View("Cart", cart);
        }
        [HttpGet]
        public IActionResult CheckOut() => View();
        [HttpPost]
        public IActionResult CheckOut(Order order) {
            if (ModelState.IsValid) {
                Order.AddOrder(order);
                return View("OrderPlaced", Order.Orders.Count());
            }
            else {
                return View();
            }
        }
        public IActionResult OrderPlaced(int OrderId) => View(OrderId);
    }
}