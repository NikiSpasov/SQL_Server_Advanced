namespace ProductsShop.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public List<Product> SoldProducts { get; set; } = new List<Product>();
        public List<Product> BoughtProducts { get; set; } = new List<Product>();
    }
}
