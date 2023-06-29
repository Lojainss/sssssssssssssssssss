namespace E_Commerce.Models {
    public class Product {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Genre  { get; set; } = "None";
        public string Description { get; set; } = "No Description yet";
        public byte[]? Image { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; } 
    }
}