namespace E_Commerce.Models {
    public class Order {
        [BindNever]
        [Key]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        [Required(ErrorMessage = "Please enter your username")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string? Password { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter your card number")]
        public long CardNumber { get; set; }
        [Required(ErrorMessage = "Please enter the expiry date")]
        public DateTime Expiry { get; set; }
        public string? CVV { get; set; }
    }
}