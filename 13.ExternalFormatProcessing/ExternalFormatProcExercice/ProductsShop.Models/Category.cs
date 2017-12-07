namespace ProductsShop.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [MaxLength(15), MinLength(3)]
        public string Name { get; set; }

        public ICollection<CategoryProducts> CategoryProducts { get; set; }= new List<CategoryProducts>();
        public ICollection<Product> Products  { get; set; } = new List<Product>();
    }
}
