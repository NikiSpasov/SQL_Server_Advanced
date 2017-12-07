namespace ProductsShop.Models
{
    using ProductsShop.Models;

    public class CategoryProducts
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
